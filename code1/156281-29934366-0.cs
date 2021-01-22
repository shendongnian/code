    public abstract class MyContext<T, key> : IDisposable where T : class {
        private DbEntities db;    //my database context
        private DbSet<T> entities;  //specific set
        protected MyContext(DbEntities db) {
            entities = db.Set<T>();
            this.db = db;
        }
        public T Add(T entity) {
            entities.Add(entity);
            db.SaveChanges();
            return entity;
        }
        
        public T Get(key id) {
            return entities.Find(id);
        }
        public List<T> GetAll() {
            return entities.ToList();
        }
        public void Delete(key id) { 
            T objectToDelete=entities.Find(id);
            if(objectToDelete!=null){
                entities.Remove(objectToDelete);
                db.SaveChanges();
            }  
        }
        public void Delete(T entity) {
            entities.Remove(entity);
            db.SaveChanges();
        }
        public void Delete(List<T> items) {
            foreach (T entity in items) {
                entities.Remove(entity);
            }
            db.SaveChanges();
        }
        public void Update(T entity) {
            entities.Attach(entity);
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
        }
        public abstract void Dispose();
    }
