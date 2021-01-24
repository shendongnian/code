    class Program
    {
        static void Main(string[] args)
        {
            var type = typeof(IWork<>);
            var types = AppDomain.CurrentDomain.GetAssemblies()
                        .SelectMany(s => s.GetTypes())
                        .Where(p => p.GetInterfaces().Any(i=> i.IsGenericType && i.GetGenericTypeDefinition() == type))
                        .ToArray();
            // types will contain GenericClass, Cls2,Cls,DerivedInterface  defined below
        }
    }
    public interface IWork<T>
    {
        void Work(object session, T json);
    }
    class GenericClass<T> : IWork<T>
    {
        public void Work(object session, T json)
        {
            throw new NotImplementedException();
        }
    }
    class Cls2 : IWork<string>
    {
        public void Work(object session, string json)
        {
            throw new NotImplementedException();
        }
    }
    class Cls : GenericClass<string> { }
    interface DerivedInterface : IWork<string> { }
