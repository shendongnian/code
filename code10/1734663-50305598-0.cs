    public class ObjectDataSource<T> : BindingList<T>
        where T: BusinessKey
    {
        System.Threading.ReaderWriterLockSlim loc;
    
        public ObjectDataSource()
        {
            loc = new System.Threading.ReaderWriterLockSlim(System.Threading.LockRecursionPolicy.NoRecursion);
    
        }
    
    
        protected override void OnListChanged(ListChangedEventArgs e)
        {
            base.OnListChanged(e);            
        }
        protected void Database_OnRemove(T[] e)
        {
            loc.EnterWriteLock();
            try
            {
                foreach (var item in e)
                {
                    var ix = Find(item);
                    if(ix>=0)
                        OnListChanged(new ListChangedEventArgs(ListChangedType.ItemDeleted, ix));
                    Data.Remove(item);
                }
            }
            finally
            {
                if(loc.IsWriteLockHeld)
                    loc.ExitWriteLock();
            }
    
    
        }
    
        protected void Database_OnAdd(T[] e)
        {
            foreach (var item in e)
                Data.Add(item);
    
    
            loc.EnterWriteLock();
            try
            {
                foreach (var item in e)
                {
                    Data.Add(item);
                    var ix = Find(item);
                    if (ix >= 0)
                        OnListChanged(new ListChangedEventArgs(ListChangedType.ItemDeleted, ix));
                }
            }
            finally
            {
                if (loc.IsWriteLockHeld)
                    loc.ExitWriteLock();
            }
    
        }
    
        protected IDataSource<T>  Database { get; }
        protected BindingList<T> Data { get; set; }
    
        protected override bool SupportsSearchingCore => true;
        protected override bool IsSortedCore => false;
        protected override bool SupportsChangeNotificationCore => true;
    
        protected override int FindCore(PropertyDescriptor prop, object key)
        {
            int result = -1;
            if (key == null)
                return result;
    
                
            PropertyInfo propInfo = typeof(T).GetProperty(prop.Name);
            if(propInfo==null)
    
            loc.EnterReadLock();
            try
            {
                T item;
                Parallel.For(0, Items.Count, (x,state) => 
                {
                    item = Items[x];
                    if (propInfo.GetValue(item, null).Equals(key))
                        result =x;
                    state.Break();
    
                });
                
                }
            finally
            {
                if (loc.IsReadLockHeld)
                    loc.ExitReadLock();
            }              
                
            return result;
        }
    
        protected int Find(BusinessKey item )
        {
            int result = -1;
            if (item == null)
                return result;
    
    
            loc.EnterReadLock();
            try
            {
    
                Parallel.For(0, Items.Count, (x, state) =>
                {
                    if (item.ID==item.ID)
                        result = x;
                    state.Break();
    
                });
    
            }
            finally
            {
                if (loc.IsReadLockHeld)
                    loc.ExitReadLock();
            }
    
            return result;
        }
    
    
             
    }
