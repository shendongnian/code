    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace MvcRepository
    {
        public class Repository<T> : IRepository<T> where T : class
        {
            protected System.Data.Linq.DataContext _dataContextFactory;
    
            public IQueryable<T> All()
            {
                return GetTable.AsQueryable();
            }
    
            public IQueryable<T> FindAll(Func<T, bool> exp)
            {
                return GetTable.Where<T>(exp).AsQueryable();
            }
    
            public T Single(Func<T, bool> exp)
            {
                return GetTable.Single(exp);
            }
    
            public virtual void MarkForDeletion(T entity)
            {
                _dataContextFactory.GetTable<T>().DeleteOnSubmit(entity);
            }
    
            public virtual T CreateInstance()
            {
                T entity = Activator.CreateInstance<T>();
                GetTable.InsertOnSubmit(entity);
                return entity;
            }
    
            public void SaveAll()
            {
                _dataContextFactory.SubmitChanges();
            }
    
            public Repository(System.Data.Linq.DataContext dataContextFactory)
            {
                _dataContextFactory = dataContextFactory;
            }
    
            public System.Data.Linq.Table<T> GetTable
            {
                get { return _dataContextFactory.GetTable<T>(); }
            }
    
        }
    }
