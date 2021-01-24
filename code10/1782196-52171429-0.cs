    public class Transaction : FullAuditedEntity<Guid>, IMustHaveTenant
    {
        protected Transaction()
        {
            TransactionState = TransactionState.Uncompleted;
        }
        public TransactionState TransactionState { get; protected set; }
        public virtual Loan Loan { get; protected set; }
        // ...
        internal void Abort()
        {
            TransactionState = TransactionState.Failed;
        }
        internal void Complete()
        {
            TransactionState = TransactionState.Completed;
        }
    }
