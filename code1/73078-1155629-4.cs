        public static int Count(this IEnumerable source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            ICollection collectionSource = source as ICollection;
            if (collectionSource != null)
            {
                return collectionSource.Count;
            }
            int num = 0;
            IEnumerator enumerator = source.GetEnumerator();
            //try-finally block to ensure Enumerator gets disposed if disposable
            try
            {
                while (enumerator.MoveNext())
                {
                    num++;
                }
            }
            finally
            {
                // check for disposal
                IDisposable disposableEnumerator = enumerator as IDisposable;
                if(disposableEnumerator != null)
                {
                    disposableEnumerator.Dispose();
                }
            }
            return num;
        }
