    [Serializable]
    public abstract class Command
    {
        public abstract void Execute();
    }
    [Serializable]
    public abstract class CreateCommand<T> : Command
    {
        public T Item { get; protected set; }
    }
    public class Factory<T>
    {
        private static readonly object _SyncLock = new object();
        private static Func<T> _CreateFunc;
        private static Dictionary<string, Func<T>> _CreateFuncDictionary;
        /// <summary>
        /// Registers a default Create Func delegate for type <typeparamref name="T"/>.
        /// </summary>
        public static void Register(Func<T> createFunc)
        {
            lock (_SyncLock)
            {
                _CreateFunc = createFunc;
            }
        }
        public static T Create()
        {
            lock (_SyncLock)
            {
                if(_CreateFunc == null)
                    throw new InvalidOperationException(string.Format("A [{0}] delegate must be registered as the default delegate for type [{1}]..", typeof(Func<T>).FullName, typeof(T).FullName));
                return _CreateFunc();
            }
        }
        /// <summary>
        /// Registers a Create Func delegate for type <typeparamref name="T"/> using the given key.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="createFunc"></param>
        public static void Register(string key, Func<T> createFunc)
        {
            lock (_SyncLock)
            {
                if (_CreateFuncDictionary == null)
                    _CreateFuncDictionary = new Dictionary<string, Func<T>>();
                _CreateFuncDictionary[key] = createFunc;
            }
        }
        public static T Create(string key)
        {
            lock (_SyncLock)
            {
                Func<T> createFunc;
                if (_CreateFuncDictionary != null && _CreateFuncDictionary.TryGetValue(key, out createFunc))
                    return createFunc();
                else
                    throw new InvalidOperationException(string.Format("A [{0}] delegate must be registered with the given key \"{1}\".", typeof(Func<T>).FullName, key));
            }
        }
    }
    [Serializable]
    public class CreateCommandWithDefaultDelegate<T> : CreateCommand<T>
    {
        public override void Execute()
        {
            this.Item = Factory<T>.Create();
        }
    }
    [Serializable]
    public class CreateCommandWithKeyedDelegate<T> : CreateCommand<T>
    {
        public string CreateKey { get; set; }
        public CreateCommandWithKeyedDelegate(string createKey)
        {
            this.CreateKey = createKey;
        }
        public override void Execute()
        {
            this.Item = Factory<T>.Create(this.CreateKey);
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
    class PublicPropertiesExample
    {
        public int A { get; set; }
        public string B { get; set; }
        public float C { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // register delegates for each type
            Factory<DefaultConstructorExample>.Register(() => new DefaultConstructorExample());
            Factory<NoDefaultConstructorExample>.Register(() => new NoDefaultConstructorExample(5, "ABC", 7.1f));
            Factory<PublicPropertiesExample>.Register(() => new PublicPropertiesExample() { A = 5, B = "ABC", C = 7.1f });
            // create commands
            var command1 = new CreateCommandWithDefaultDelegate<DefaultConstructorExample>();
            var command2 = new CreateCommandWithDefaultDelegate<DefaultConstructorExample>();
            var command3 = new CreateCommandWithDefaultDelegate<DefaultConstructorExample>();
            // verify that each command can be serialized/deserialized and that the creation logic works
            VerifySerializability<DefaultConstructorExample>(command1);
            VerifySerializability<DefaultConstructorExample>(command2);
            VerifySerializability<DefaultConstructorExample>(command3);
            
            // register additional delegates for each type, distinguished by key
            Factory<DefaultConstructorExample>.Register("CreateCommand", () => new DefaultConstructorExample());
            Factory<NoDefaultConstructorExample>.Register("CreateCommand", () => new NoDefaultConstructorExample(5, "ABC", 7.1f));
            Factory<PublicPropertiesExample>.Register("CreateCommand", () => new PublicPropertiesExample() { A = 5, B = "ABC", C = 7.1f });
            // create commands, passing in the create key to the constructor
            var command4 = new CreateCommandWithKeyedDelegate<DefaultConstructorExample>("CreateCommand");
            var command5 = new CreateCommandWithKeyedDelegate<DefaultConstructorExample>("CreateCommand");
            var command6 = new CreateCommandWithKeyedDelegate<DefaultConstructorExample>("CreateCommand");
            // verify that each command can be serialized/deserialized and that the creation logic works
            VerifySerializability<DefaultConstructorExample>(command4);
            VerifySerializability<DefaultConstructorExample>(command5);
            VerifySerializability<DefaultConstructorExample>(command6);
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
