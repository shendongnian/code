    class Program
    {
        public interface IComponent { }
        public class ComponentA : IComponent { }
        public class ComponentB : IComponent { }
        static void Main(string[] args)
        {
            HandleComponents(new[] { typeof(ComponentB), typeof(ComponentA) });
            Console.ReadKey();
        }
        private static void HandleComponent<T>()
            where T : IComponent
        {
            Console.WriteLine(typeof(T));
        }
        private static void HandleComponents(Type[] components)
        {
            var m = typeof(Program).GetMethod("HandleComponent");
            foreach (var component in components)
            {
                if (typeof(IComponent).IsAssignableFrom(component))
                {
                    var genericMethod = m.MakeGenericMethod(component);
                    genericMethod.Invoke(null, null);
                }
            }
        }
    }
