    public class QueryProvider : IQueryProvider
    {
        // Translates LINQ query to SQL.
        private readonly Func<IQueryable, DbCommand> _translator;
        // Executes the translated SQL and retrieves results.
        private readonly Func<Type, string, object[], IEnumerable> _executor;
        public QueryProvider(
            Func<IQueryable, DbCommand> translator,
            Func<Type, string, object[], IEnumerable> executor)
        {
            
            this._translator = translator;
            this._executor = executor;
        }
        #region IQueryProvider Members
        public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
        {
            return new Queryable<TElement>(this, expression);
        }
        public IQueryable CreateQuery(Expression expression)
        {
            throw new NotImplementedException();
        }
        public TResult Execute<TResult>(Expression expression)
        {
            bool isCollection = typeof(TResult).IsGenericType &&
                typeof(TResult).GetGenericTypeDefinition() == typeof(IEnumerable<>);
            var itemType = isCollection
                // TResult is an IEnumerable`1 collection.
                ? typeof(TResult).GetGenericArguments().Single()
                // TResult is not an IEnumerable`1 collection, but a single item.
                : typeof(TResult);
            var queryable = Activator.CreateInstance(
                typeof(Queryable<>).MakeGenericType(itemType), this, expression) as IQueryable;
            IEnumerable queryResult;
            // Translates LINQ query to SQL.
            using (var command = this._translator(queryable))
            {
                var parameters = command.Parameters.OfType<DbParameter>()
                    .Select(parameter => parameter)
                    .ToList();
                var query = command.CommandText;
                var newParameters = GetNewParameterList(ref query, parameters);
                                
                queryResult = _executor(itemType,query,newParameters);
            }
            return isCollection
                ? (TResult)queryResult // Returns an IEnumerable`1 collection.
                : queryResult.OfType<TResult>()
                             .SingleOrDefault(); // Returns a single item.
        }       
        public object Execute(Expression expression)
        {
            throw new NotImplementedException();
        }
        #endregion
         private static object[] GetNewParameterList(ref string query, List<DbParameter> parameters)
        {
            var newParameters = new List<DbParameter>(parameters);
            foreach (var dbParameter in parameters.Where(p => p.DbType == System.Data.DbType.Int32))
            {
                var name = dbParameter.ParameterName;
                var value = dbParameter.Value != null ? dbParameter.Value.ToString() : "NULL";
                var pattern = String.Format("{0}[^0-9]", dbParameter.ParameterName);
                query = Regex.Replace(query, pattern, match => value + match.Value.Replace(name, ""));
                newParameters.Remove(dbParameter);
            }
            for (var i = 0; i < newParameters.Count; i++)
            {
                var parameter = newParameters[i];
                var oldName = parameter.ParameterName;
                var pattern = String.Format("{0}[^0-9]", oldName);
                var newName = "@p" + i;
                query = Regex.Replace(query, pattern, match => newName + match.Value.Replace(oldName, ""));
            }      
            return newParameters.Select(x => x.Value).ToArray();
        }
    }
        static void Main(string[] args)
        {
            using (var dc=new DataContext())
            {
                var provider = new QueryProvider(dc.GetCommand, dc.ExecuteQuery);
                var serviceIds = Enumerable.Range(1, 2200).ToArray();
           
                var tasks = new Queryable<Task>(provider, dc.Tasks).Where(x => serviceIds.Contains(x.ServiceId) && x.CreatorId==37 && x.Creator.Name=="12312").ToArray();
            }
           
        }
