    class Aware {
        public static readonly IEnumerable<Type> AllTypes;
        static Aware() {
            Type awareType = typeof(Aware);
            allTypes = Assembly.GetAssembly(awareType)
                               .GetTypes()
                               .Where(t => awareType.IsAssignableFrom(t));        
        }
    }
