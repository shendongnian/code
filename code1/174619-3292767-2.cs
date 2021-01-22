    [Serializable]
    public abstract class Command
    {
        public abstract void Execute();
    }
    public class Factory
    {
        static Dictionary<Type, Func<object[], object>> _DelegateCache = new Dictionary<Type, Func<object[], object>>();
        public static void Register<T>(Func<object[], object> @delegate)
        {
            _DelegateCache[typeof(T)] = @delegate;
        }
        public static T CreateMyType<T>(params object[] args)
        {
            return (T)_DelegateCache[typeof(T)](args);
        }
    }
    public interface IFactory<T>
    {
        T Create();
    }
    [Serializable]
    public class CreateCommand<T> : Command
    {
        public T Item { get; protected set; }
        protected IFactory<T> _ItemFactory;
        public CreateCommand(IFactory<T> itemFactory)
        {
            this._ItemFactory = itemFactory;
        }
        public override void Execute()
        {
            this.Item = this._ItemFactory.Create();
        }
    }
    // This class is a base class that represents a factory capable of creating an instance using a dynamic set of arguments.
    [Serializable]
    public abstract class DynamicFactory<T> : IFactory<T>
    {
        public object[] Args { get; protected set; }
        public DynamicFactory(params object[] args)
        {
            this.Args = args;
        }
        public DynamicFactory(int numberOfArgs)
        {
            if (numberOfArgs < 0)
                throw new ArgumentOutOfRangeException("numberOfArgs", "The numberOfArgs parameter must be greater than or equal to zero.");
            this.Args = new object[numberOfArgs];
        }
        #region IFactory<T> Members
        public abstract T Create();
        #endregion
    }
    // This implementation uses the Activator.CreateInstance function to create an instance
    [Serializable]
    public class DynamicConstructorFactory<T> : DynamicFactory<T>
    {
        public DynamicConstructorFactory(params object[] args) : base(args) { }
        public DynamicConstructorFactory(int numberOfArgs) : base(numberOfArgs) { }
        public override T Create()
        {
            return (T)Activator.CreateInstance(typeof(T), this.Args);
        }
    }
    // This implementation uses the Factory.CreateMyType function to create an instance
    [Serializable]
    public class MyTypeFactory<T> : DynamicFactory<T>
    {
        public MyTypeFactory(params object[] args) : base(args) { }
        public MyTypeFactory(int numberOfArgs) : base(numberOfArgs) { }
        public override T Create()
        {
            return Factory.CreateMyType<T>(this.Args);
        }
    }
    [Serializable]
    class DefaultConstructorExample
    {
        public DefaultConstructorExample()
        {
        }
    }
    [Serializable]
    class NoDefaultConstructorExample
    {
        public NoDefaultConstructorExample(int a, string b, float c)
        {
        }
    }
    [Serializable]
    class PrivateConstructorExample
    {
        private int _A;
        private string _B;
        private float _C;
        private PrivateConstructorExample()
        {
        }
        public static void Register()
        {
            // register a delegate with the Factory class that will construct an instance of this class using an array of arguments
            Factory.Register<PrivateConstructorExample>((args) =>
                {
                    if (args == null || args.Length != 3)
                        throw new ArgumentException("Expected 3 arguments.", "args");
                    if (!(args[0] is int))
                        throw new ArgumentException("First argument must be of type System.Int32.", "args[0]");
                    if (!(args[1] is string))
                        throw new ArgumentException("Second argument must be of type System.String.", "args[1]");
                    if (!(args[2] is float))
                        throw new ArgumentException("Third argument must be of type System.Single.", "args[2]");
                    var instance = new PrivateConstructorExample();
                    instance._A = (int)args[0];
                    instance._B = (string)args[1];
                    instance._C = (float)args[2];
                    return instance;
                });
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var factory1 = new DynamicConstructorFactory<DefaultConstructorExample>(null);
            var command1 = new CreateCommand<DefaultConstructorExample>(factory1);
            var factory2 = new DynamicConstructorFactory<NoDefaultConstructorExample>(3);
            factory2.Args[0] = 5;
            factory2.Args[1] = "ABC";
            factory2.Args[2] = 7.1f;
            var command2 = new CreateCommand<NoDefaultConstructorExample>(factory2);
            PrivateConstructorExample.Register(); // register this class so that it can be created by the Factory.CreateMyType function
            var factory3 = new MyTypeFactory<PrivateConstructorExample>(3);
            factory3.Args[0] = 5;
            factory3.Args[1] = "ABC";
            factory3.Args[2] = 7.1f;
            var command3 = new CreateCommand<PrivateConstructorExample>(factory3);
            VerifySerializability<DefaultConstructorExample>(command1);
            VerifySerializability<NoDefaultConstructorExample>(command2);
            VerifySerializability<PrivateConstructorExample>(command3);
        }
        static void VerifySerializability<T>(CreateCommand<T> originalCommand)
        {
            var serializer = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            using (var stream = new System.IO.MemoryStream())
            {
                System.Diagnostics.Debug.Assert(originalCommand.Item == null); // assert that originalCommand does not yet have a value for Item
                serializer.Serialize(stream, originalCommand); // serialize the originalCommand object
                stream.Seek(0, System.IO.SeekOrigin.Begin); // reset the stream position to the beginning for deserialization
                // deserialize
                var deserializedCommand = serializer.Deserialize(stream) as CreateCommand<T>;
                System.Diagnostics.Debug.Assert(deserializedCommand.Item == null); // assert that deserializedCommand still does not have a value for Item
                deserializedCommand.Execute();
                System.Diagnostics.Debug.Assert(deserializedCommand.Item != null); // assert that deserializedCommand now has a value for Item
            }
        }
    }
