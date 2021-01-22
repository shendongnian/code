        public static int Count(this IEnumerable source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            ICollection is2 = source as ICollection;
            if (is2 != null)
            {
                return is2.Count;
            }
            int num = 0;
            IEnumerator enumerator = source.GetEnumerator();
            while (enumerator.MoveNext())
            {
                num++;
            }
            return num;
        }
