        public static IEnumerable<T> Sequence<T>(Func<T> generator, int count)
        {
            for (int i = 0; i < count; i++)
            {
                yield return generator();
            }
        }
        ...
        var myArr = Sequence(() => new double[colCount], rowCount).ToArray();
