    public static class TypeHelpers<TInput>
    {
        public static Type GetReturnType<TOutput>(Func<TInput, TOutput> func) =>
            typeof(TOutput);
    }
