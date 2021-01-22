    namespace ABC
    {
        public class EntitiesRepository<T> : IDisposable where T : class
        {
            private ObjectContext _context;
    
            /// <summary>
            /// The IObjectSet that represents the current entity.
            /// </summary>
            private ObjectSet<T> _objectSet;
    
            public OperationStatus status { get; set; }
    
            /// <summary>
            /// Initializes a new instance of the DataRepository class
            /// </summary>
            public BilderQuizEntitiesRepository()
            {
                _context = new Entities();  //DBContext
    
                _objectSet = _context.CreateObjectSet<T>();
             }
    
            public T Select(int id)
            {
                EntityKey key = GetEntityKey(id);
    
                return (T)_context.GetObjectByKey(key);
            }
           
            public void Delete(T entity)
            {
                try
                {
                    if (entity == null)
                    {
    
                        throw new ArgumentNullException("entity");
                    }
    
                    EntityKey key = GetEntitySpecificKey(entity);
                    T attachEntity = (T)_context.GetObjectByKey(key);
                    _objectSet.DeleteObject(attachEntity);
                    SaveChanges();                
                }
                catch
                {
                   
                }
                
            }       
    
            public void Delete(int id)
            {
                EntityKey key = GetEntityKey(id);
                Delete((T)_context.GetObjectByKey(key));
                SaveChanges();
            }
    
            public void Update(T entity)
            {
                try
                {
                    if (entity == null)
                    {
    
                        throw new ArgumentNullException("entity");
                    }
    
                    EntityKey key = GetEntitySpecificKey(entity);
                    T attachEntity = (T)_context.GetObjectByKey(key);
                    _objectSet.Attach(attachEntity);
                    _objectSet.ApplyCurrentValues(entity);
                    SaveChanges();
                    
                }
                catch
                {
                   
                }
               
            }       
    
            /// <summary>
            /// Returns Entity Key 
            /// </summary>
            /// <param name="keyValue"></param>
            /// <returns></returns>
            private EntityKey GetEntityKey(object keyValue) //Get EnrityKey
            {
                var entitySetName = _context.DefaultContainerName + "." + _objectSet.EntitySet.Name;
                var keyPropertyName = _objectSet.EntitySet.ElementType.KeyMembers[0].ToString();
                var entityKey = new EntityKey(entitySetName, new[] { new EntityKeyMember(keyPropertyName, keyValue) });
                return entityKey;
            }
    
            /// <summary>
            /// Returns Entity Key 
            /// </summary>
            /// <param name="keyValue"></param>
            /// <returns></returns>
            private EntityKey GetEntitySpecificKey(T entity) //Get EnrityKey
            {
                Type objType = typeof(T);
                var keyPropertyName = _objectSet.EntitySet.ElementType.KeyMembers[0].ToString();
                var pi = objType.GetProperty(keyPropertyName);
                var keyValue = pi.GetValue(entity, null);
                var entitySetName = _context.DefaultContainerName + "." + _objectSet.EntitySet.Name;
    
                var entityKey = new EntityKey(entitySetName, new[] { new EntityKeyMember(keyPropertyName, keyValue) });
                return entityKey;
            }
    
            private string GetPrimaryKeyValue(T entity)
            {
                Type objType = typeof(T);
                var keyPropertyName = _objectSet.EntitySet.ElementType.KeyMembers[0].ToString();
                var pi = objType.GetProperty(keyPropertyName);
                var keyValue = pi.GetValue(entity, null);
                return keyValue.ToString();
            }
    
            /// <summary>
            /// Saves all context changes
            /// </summary>
            public bool SaveChanges()
            {
                return _context.SaveChanges() > 0 ? true : false;
            }
    
            /// <summary>
            /// Releases all resources used by the WarrantManagement.DataExtract.Dal.ReportDataBase
            /// </summary>
            public void Dispose()
            {
    
                Dispose(true);
    
                GC.SuppressFinalize(this);
    
            }
    
            /// <summary>
            /// Releases all resources used by the WarrantManagement.DataExtract.Dal.ReportDataBase
            /// </summary>
            /// <param name="disposing">A boolean value indicating whether or not to dispose managed resources</param>
            protected virtual void Dispose(bool disposing)
            {
    
                if (disposing)
                {
    
                    if (_context != null)
                    {
    
                        _context.Dispose();
    
                        _context = null;
    
                    }
    
                }
    
            }
        }
    
    }
