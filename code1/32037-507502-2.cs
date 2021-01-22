        public static void myFunc<T>()
        {
            Type t = typeof(T);
            if (!t.IsEnum)
                throw new InvalidOperationException("Type is not Enum");
            var names = Enum.GetNames(t);
            foreach (var name in names)
            {
                // do something!
            }
        }
