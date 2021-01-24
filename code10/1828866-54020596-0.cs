    class Program
    {
        static void Main(string[] args)
        {
            A a1 = A.GetInstance("a");
            A a2 = A.GetInstance("aa");
            A a3 = A.GetInstance("a");
            B b1 = B.GetInstance("a");
            B b2 = B.GetInstance("aa");
            B b3 = B.GetInstance("a");
            Console.WriteLine(a1 == a2); //false
            Console.WriteLine(a1 == a3); //true
            Console.WriteLine(b1 == b2); //false
            Console.WriteLine(b1 == b3); //true
            Console.ReadKey();
        }
    }
    public class A : Generic<A>
    {
        public A(string name)
            : base(name)
        {
        }
    }
    public class B : Generic<B>
    {
        public B(string name)
            : base(name)
        {
        }
    }
    public abstract class Generic<T> where T : Generic<T>
    {
        private static readonly IDictionary<string, T> Registry = new Dictionary<string, T>();
        public string Name { get; set; }
        public Generic(string name)
        {
            this.Name = name;
        }
        public static T GetInstance(string instanceName)
        {
            lock (Registry)
            {
                if (!Registry.TryGetValue(instanceName, out var newInstance))
                {
                    newInstance = (T)Activator.CreateInstance(typeof(T), instanceName);
                    Registry.Add(instanceName, newInstance);
                }
                return newInstance;
            }
        }
    }
