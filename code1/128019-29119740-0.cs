        public class DALXmlRepository<T> where T : class
        {
        public T GetItem(Array predicate)
        {
            IQueryable<T> QueryList = null;
            
            QueryList = ObjectList.AsQueryable<T>().Where((Expression<Func<T, bool>>)predicate.GetValue(0));
            for (int i = 1; i < predicate.GetLength(0); i++)
            {
                QueryList = QueryList.Where((Expression<Func<T, bool>>)predicate.GetValue(i));
            }
            if (QueryList.FirstOrDefault() == null)
                throw new InvalidOperationException(this.GetType().GetGenericArguments().First().Name + " not found.");
            return QueryList.FirstOrDefault();
        }
        }
