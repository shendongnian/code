    public class ErrorLogger
    {
        private MyDataContext db;
        public ErrorLogger(MyDataContext db) => this.db = db;
        public void LogError(IExceptionHandlerFeature error)
        {
            Log log = new Log();
            log.Message = error.Error.Message; 
         
            UnitOfWork uow = new UnitOfWork(this.db);
            uow.LogRepo.AddOrUpdate(log);
            await uow.CompleteAsync(false);
        }
    }
