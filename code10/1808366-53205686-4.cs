    public static class MyTypeExtensions
    {
        public static T ToAnyEnum<T>(this MyType myType)
        {
            return (T)Enum.ToObject(typeof(T), myType.value);
        }
    }
