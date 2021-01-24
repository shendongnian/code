      public static readonly GetLength ByCount = o =>
        {
            var type = o.GetType();
            var prop = type.GetProperty("Count");
            object p = prop.GetValue(o, null);
            return (int)p;
        };
        public static readonly GetLength ByLength = o =>
        {
            var type = o.GetType();
            var prop = type.GetProperty("Length");
            object p = prop.GetValue(o, null);
            return (int)p;
        };
