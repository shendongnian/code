    class MyClass
    {
        private static readonly IDictionary<MyEnum, String> dic = new Dictionary<MyEnum, String>
        {
            { MyEnum.EnGb, "en-gb" },
            { MyEnum.RuRu, "ru-ru" },
            ...
        };
    
        public static IDictionary<MyEnum, String> Dic { get { return dic; } }
    }
