    public class MainLogicClassExample //Catty out logi operations on objects and update DataBase
    {
        public void NewEmailRecipient(EF.EmailRecipient recipient)
        {
            // logic operation here
    
            EntityToDB(recipient);
        }
        public void NewReportRecipient(EF.ReportRecipient recipient)
        {
            // logic operation here
    
            EntityToDB(recipient);
        }
        public void UpdateEmailRecipient(EF.EmailRecipient recipient)
        {
            // logic operation here
    
            UpdateEntity(recipient);
        }
    
        public void UpdateReportRecipient(EF.ReportRecipient recipient)
        {
            // logic operation here
    
            UpdateEntity(recipient);
        }
        // call generic methods to update DB
        private void EntityToDB<T>(T entity) where T : class
        {
            var context = new ContextHelper<T>();
            context.Insert(entity);
        }
    
        private void UpdateEntity<T>(T entity) where T : class
        {
            var context = new ContextHelper<T>();
            context.Update(entity);
        }
    }
