    public ResourceManager<T>
    {
         private Dictionary<uint,WeakReference> Cache = new Dictionary<uint,WeakReference>();
         public T this[uint key]
         {
             var obj = (T)this.Cache[key].Target;
             if (obj == null)
             {
                 obj = ...recreate resource...
                 this.Cache[key] = obj;
             }
             return obj;
         }
         public void Remove( uint key )
         {
             this.Cache.Remove(key);
         }
    }
