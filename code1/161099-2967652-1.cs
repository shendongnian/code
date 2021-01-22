    static class Anonymous
    {
        public static IA<ResultClass> A<ResultClass>(Func<string, ResultClass> fun1)
        { return new AnonymousA<ResultClass> { Fun1 = fun1 }
    }
