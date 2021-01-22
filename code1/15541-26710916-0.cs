    static class ArrayExtensions
        {
            public static string[] Add(this string[] array, string item)
            {
                return array.Concat(new[] {item}).ToArray();
            }
        }
