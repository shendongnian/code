        public class ModelDbContext : DbContext
        {
        
            public IEnumerable<TOutput> FunctionTableValue<TOutput>(string functionName, SqlParameter[] parameters)
            {
                    parameters = parameters ?? new SqlParameter[] { };
        
                    string commandText = String.Format("SELECT * FROM dbo.{0}", String.Format("{0}({1})", functionName, String.Join(",", parameters.Select(x => x.ParameterName))));
        
                    return  ObjectContext.ExecuteStoreQuery<TOutput>(commandText, parameters).ToArray();
            }
        
            private ObjectContext ObjectContext
            {
                get { return (this as IObjectContextAdapter).ObjectContext; }
            }
        }
