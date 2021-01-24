    public class MySampleClass
    {
        private readonly IUnitOfWorkManager _unitOfWorkManager;
    
        public MySampleClass(IUnitOfWorkManager unitOfWorkManager)
        {
            _unitOfWorkManager = unitOfWorkManager;
        }
    
        private void MyDbMethod()
        {
            using (var uow = _unitOfWorkManager.Begin(TransactionScopeOption.RequiresNew))
            {
                //Do your db operations...
                await _unitOfWorkManager.Current.SaveChangesAsync();
                await uow.CompleteAsync();
            }
        }
    }
