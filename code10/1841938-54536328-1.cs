        public static void PrintAlphaFoo<T>(Item<T> item)
        {
            AlphaType alphaType;
            if (!Enum.TryParse<AlphaType>(item.Value.ToString(), out alphaType))
            {
                return;
            }
            if (alphaType == AlphaType.A1)
            {
                Console.WriteLine(item.Foo);
            }
        }
