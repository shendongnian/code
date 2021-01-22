    public class TransactionScope : Scope<IDbTransaction>
    {
        public TransactionScope()
        {
            InitialiseScope(ConnectionScope.CurrentKey);
        }
    
        protected override IDbTransaction CreateItem()
        {
            return ConnectionScope.Current.BeginTransaction();
        }
    
        public void Commit()
        {
            if (CurrentScopeItem.UserCount == 1)
            {
                TransactionScope.Current.Commit();
            }
        }
    }
