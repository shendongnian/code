     foreach (var page in db.Customers .OrderBy(x => x.Id).GetPages(1000))
     {
         // page is IEnumerable<Customer> with count 1000 or less
     }
        public static IEnumerable<IEnumerable<T>> GetPages<T>(this IEnumerable<T> source, int pageSize)
        {
            int i = 0;
            IEnumerable<T> page = null;
            while (page == null || page.Count() == pageSize)
            {
                page = source.Skip(i).Take(pageSize);
                i += pageSize;
                yield return page;
            }
        }
