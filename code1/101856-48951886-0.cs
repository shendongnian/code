    public class Foo
    {
        private static readonly Dictionary<Type, dynamic> _factories = new Dictionary<Type, dynamic>();
    
        private static void AddFactory<T>(Func<Boo<T>> factory)
            => _factories[typeof(T)] = factory;
    
        public void TestMeDude<T>()
        {
            if (!_factories.TryGetValue(typeof(T), out var factory))
            {
                Console.WriteLine("Creating factory");
                RuntimeHelpers.RunClassConstructor(typeof(Boo<T>).TypeHandle);
                factory = _factories[typeof(T)];
            }
            else
            {
                Console.WriteLine("Factory previously created");
            }
    
            var boo = (Boo<T>)factory();
            boo.ToBeSure();
        }
    
        public class Boo<T>
        {
            static Boo() => AddFactory(() => new Boo<T>());
    
            private Boo() { }
    
            public void ToBeSure() => Console.WriteLine(typeof(T).Name);
        }
    }
