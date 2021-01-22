    class Alpha { }
    class Beta { }
    class Service
    {
        public void Process<T>(T item)
        {
            Console.WriteLine("item.GetType(): " + item.GetType()
                              + "\ttypeof(T): " + typeof(T));
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var a = new Alpha();
            var b = new Beta();
            var service = new Service();
            service.Process(a); // Same as "service.Process<Alpha>(a)"
            service.Process(b); // Same as "service.Process<Beta>(b)"
            var objects = new object[] { a, b };
            foreach (var o in objects)
            {
                service.Process(o); // Same as "service.Process<object>(o)"
            }
            foreach (var o in objects)
            {
                dynamic dynObj = o;
                service.Process(dynObj); // Or write "service.Process((dynamic)o)"
            }
        }
    }
