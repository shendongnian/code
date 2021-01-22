    public class MyClass : IList
    {
        private object syncRoot = new object();
            
        public void Add(object value)
        {
            lock(this.syncRoot)
            {
               // Add code here
            }
        }
        
        public void Remove(object value)
        {
            lock(this.syncRoot)
            {
                // Remove code here
            }
        }
    }
