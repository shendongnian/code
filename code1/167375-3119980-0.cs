    public abstract class ABackendObject<T> where T : class
    {
         public T LoadFromDB(int id) {
             T obj = this.CheckCache(id);
             if (obj == null)
             { 
                 obj = this.Read(id); // Load the object
                 this.SaveToCache(id, obj);
             }
             return obj;
         }
    } 
