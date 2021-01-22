    namespace MyNamespace
    {
        public static class MyExtensions
        {
            public static T GetRandom<T>(this List<T> source)
            {
                Random rnd = new Random();
                int index = rnd.Next(0, source.Count);
                T o = source[index];
                return o;
            }
        }
    }
