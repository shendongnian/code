    public interface ITransactionManager
    {
        ITransaction CurrentTransaction { get; }
        ITransactionScope CreateScope(TransactionScopeOption options);
    }
    public class TransactionManager : ITransactionManager
    {
        public ITransaction CurrentTransaction
        {
            get { return new DefaultTransaction(Transaction.Current); }
        }
        public ITransactionScope CreateScope(TransactionScopeOption options)
        {
            return new DefaultTransactionScope(new TransactionScope());
        }
    }
    public interface ITransactionScope : IDisposable
    {
        void Complete();  
    }
    public class DefaultTransactionScope : ITransactionScope
    {
        private TransactionScope scope;
        public DefaultTransactionScope(TransactionScope scope)
        {
            this.scope = scope;
        }
        public void Complete()
        {
            this.scope.Complete();
        }
        public void Dispose()
        {
            this.scope.Dispose();
        }
    }
    public interface ITransaction
    {
        void EnlistVolatile(Enlistable enlistmentNotification, EnlistmentOptions enlistmentOptions);
    }
    public class DefaultTransaction : ITransaction
    {
        private Transaction transaction;
        public DefaultTransaction(Transaction transaction)
        {
            this.transaction = transaction;
        }
        public void EnlistVolatile(Enlistable enlistmentNotification, EnlistmentOptions enlistmentOptions)
        {
            this.transaction.EnlistVolatile(enlistmentNotification, enlistmentOptions);
        }
    }
    public interface IEnlistment
    { 
        void Done();
    }
    public interface IPreparingEnlistment
    {
        void Prepared();
    }
    public abstract class Enlistable : IEnlistmentNotification
    {
        public abstract void Commit(IEnlistment enlistment);
        public abstract void Rollback(IEnlistment enlistment);
        public abstract void Prepare(IPreparingEnlistment enlistment);
        public abstract void InDoubt(IEnlistment enlistment);
        void IEnlistmentNotification.Commit(Enlistment enlistment)
        {
            this.Commit(new DefaultEnlistment(enlistment));
        }
        void IEnlistmentNotification.InDoubt(Enlistment enlistment)
        {
            this.InDoubt(new DefaultEnlistment(enlistment));
        }
        void IEnlistmentNotification.Prepare(PreparingEnlistment preparingEnlistment)
        {
            this.Prepare(new DefaultPreparingEnlistment(preparingEnlistment));
        }
        void IEnlistmentNotification.Rollback(Enlistment enlistment)
        {
            this.Rollback(new DefaultEnlistment(enlistment));
        }
        private class DefaultEnlistment : IEnlistment
        {
            private Enlistment enlistment;
            public DefaultEnlistment(Enlistment enlistment)
            {
                this.enlistment = enlistment;
            }
            
            public void Done()
            {
                this.enlistment.Done();
            }
        }
        private class DefaultPreparingEnlistment : DefaultEnlistment, IPreparingEnlistment
        {
            private PreparingEnlistment enlistment;
            public DefaultPreparingEnlistment(PreparingEnlistment enlistment) : base(enlistment)
            {
                this.enlistment = enlistment;    
            }
            
            public void Prepared()
            {
                this.enlistment.Prepared();
            }
        }
    }
