    class Test
    {
        public T CreateActor<T>()
            where T : IClass, new()
        {
            return new T();
        }
        public MyEnum eEnum { get; set; }
        public string Str { get; set; }
    }
