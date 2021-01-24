        public static void PrintAlphaFoo<T>(Item<T> item)
        {
            Enum.TryParse<AlphaType>(item.Value.ToString(), out AlphaType alphaType);
            if (alphaType == AlphaType.A1)
            {
                Console.WriteLine(item.Foo);
            }
        }
