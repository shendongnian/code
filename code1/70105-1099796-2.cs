        public static IEnumerable<TResult> Repeat<TResult>(
              Func<TResult> generator,
              int count)
        {
            for (int i = 0; i < count; i++)
            {
                yield return generator();
            }
        }
