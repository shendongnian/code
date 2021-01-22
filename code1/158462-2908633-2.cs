    public class CustomerDao : IDisposable
    {
        private DataContext context;
    
        public CustomerDao()
        {
            this.context = new DataContext("SomeConnectionString");
        }
        
        public void Insert(Customer instance)
        {
            this.context.Customers.InsertOnSubmit(instance);
            this.StartUpdateIndex();
            this.context.SubmitChanges();
        }
    
        public void Delete(Customer instance)
        {
            this.context.Customers.DeleteOnSubmit(instance);
            this.StartUpdateIndex();
            this.context.SubmitChanges();
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
            ChangeSet changes = this.context.GetChangeSet();
            ThreadPool.QueueUserWorkItem(
                state => this.UpdateIndex((ChangeSet)state), changes); 
        }
    }
