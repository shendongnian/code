    public abstract class GenericRepository<T> : IRepository<T> where T : class //EntityBase, IAggregateRoot
        {
            private readonly string _tableName;
            internal IDbConnection Connection
            {
                get
                {
                    return new SqlConnection(ConfigurationManager.ConnectionStrings["SmsQuizConnection"].ConnectionString);
                }
            }
            public GenericRepository(string tableName)
            {
                _tableName = tableName;
            }
            internal virtual dynamic Mapping(T item)
            {
                return item;
            }
            public virtual void Add(T item)
            {
                using (IDbConnection cn = Connection)
                {
                    var parameters = (object)Mapping(item);
                    cn.Open();
                    item.ID = cn.Insert<Guid>(_tableName, parameters);
                }
            }
            public virtual void Update(T item)
            {
                using (IDbConnection cn = Connection)
                {
                    var parameters = (object)Mapping(item);
                    cn.Open();
                    cn.Update(_tableName, parameters);
                }
            }
            public virtual void Remove(T item)
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();
                    cn.Execute("DELETE FROM " + _tableName + " WHERE ID=@ID", new { ID = item.ID });
                }
            }
            public virtual T FindByID(Guid id)
            {
                T item = default(T);
                using (IDbConnection cn = Connection)
                {
                    cn.Open();
                    item = cn.Query<T>("SELECT * FROM " + _tableName + " WHERE ID=@ID", new { ID = id }).SingleOrDefault();
                }
                return item;
            }
            
            public virtual IEnumerable<T> FindAll()
            {
                IEnumerable<T> items = null;
                using (IDbConnection cn = Connection)
                {
                    cn.Open();
                    items = cn.Query<T>("SELECT * FROM " + _tableName);
                }
                return items;
            }
            
        }
