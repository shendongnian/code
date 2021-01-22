    public interface ITransactionManager
    {
        ITransaction CurrentTransaction { get; }
        ITransactionScope CreateScope(TransactionScopeOption options);
    }
    public interface ITransactionScope
        : IDisposable
    {
        void Complete();  
    }
    public interface ITransaction
    {
        void EnlistVolatile(IEnlistmentNotification enlistmentNotification);
    }
    public interface IEnlistment
    { 
        void Done();
    }
    public interface IPreparingEnlistment
    {
        void Prepared();
    }
    public interface IEnlistable // The same as IEnlistmentNotification but it has
                                 // to be redefined since the Enlistment-class
                                 // has no public constructor so it's not mockable.
    {
        void Commit(IEnlistment enlistment);
        void Rollback(IEnlistment enlistment);
        void Prepare(IPreparingEnlistment enlistment);
        void InDoubt(IEnlistment enlistment);
    }
