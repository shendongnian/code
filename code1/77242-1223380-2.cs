        interface IRepository<T> : IDisposable where T : class
        {
            IEnumerable<T> FindAll(Func<T, bool> predicate);
            T FindByID(Func<T, bool> predicate);
            void Insert(T e);
            void Update(T e);
            void Delete(T e);
        }
        class MyRepository<T> : IRepository<T> where T : class
        {
            public DataContext Context { get; set; }
            public MyRepository(DataContext context)
            {
                Context = Context;
            }
            public IEnumerable<T> FindAll(Func<T,bool> predicate)
            {
                return Context.GetTable<T>().Where(predicate);
            }
            public T FindByID(Func<T,bool> predicate)
            {
                return Context.GetTable<T>().SingleOrDefault(predicate);
            }
            public void Insert(T e)
            {
                Context.GetTable<T>().InsertOnSubmit(e);
            }
            public void Update(T e)
            {
                throw new NotImplementedException();
            }
            public void Delete(T e)
            {
                Context.GetTable<T>().DeleteOnSubmit(e);
            }
            public void Dispose()
            {
                Context.Dispose();
            }
        }
        
