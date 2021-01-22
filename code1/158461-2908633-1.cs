    public class CustomerDao : IDisposable
    {
        private DataContext context;
        private object syncObject;
    
        public CustomerDao()
        {
            this.context = new DataContext("SomeConnectionString");
            this.syncObject = new object();
        }
        
        public void Insert(Customer instance)
        {
            lock (syncObject)
            {
                this.context.Customers.InsertOnSubmit(instance);
                this.StartUpdateIndex();
                this.context.SubmitChanges();
            }
        }
    
        public void Delete(Customer instance)
        {
            lock (syncObject)
            {
                this.context.Customers.DeleteOnSubmit(instance);
                this.StartUpdateIndex();
                this.context.SubmitChanges();
            }
        }
        
        public void Dispose()
        {
            if (this.context != null)
            {
                this.context.Dispose();
            }         
        }
         
        private void StartUpdateIndex()
        {
            ThreadPool.QueueUserWorkItem(
                state => this.UpdateIndex(this.context.GetChangeSet())); 
        }
    }
