    public class ThisObject
    {
        private readonly ObjectPool<That> pool = new ObjectPool<That>(100);
    
        public void ThisMethod()
        {
            var that = pool.Get();
    
            try
            { 
                // Use that ....
            }
            finally
            {
                pool.Put(that);
            }
        }
    }
