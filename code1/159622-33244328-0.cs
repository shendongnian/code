    public static class TypeExtensions
    {
        public T CreateInstance<T>(this T type) where T : Type
        {
            var constructor = type.GetConstructor(Type.EmptyTypes);
            return /* valid to instantiate test */ ? constructor.Invoke(null) : null;
        }
    }
