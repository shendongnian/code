     public enum TestEnum
     { 
            [Description("Something 1")]
            Dr = 0,
            [Description("Something 2")]
            Mr = 1
     }
        static void Main(string[] args)
        {
            var vals = StaticClass.GetEnumFormattedNames<TestEnum>();
        }
