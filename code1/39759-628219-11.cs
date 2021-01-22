    public class Foo
    {
        private ITransactionManager transactionManager;
        public Foo(ITransactionManager transactionManager)
        {
            this.transactionManager = transactionManager;
        }
        public void DoSomethingTransactional()
        {
            var command = new TransactionalCommand();
            using (var scope = this.transactionManager.CreateScope(TransactionScopeOption.Required))
            {
                this.transactionManager.CurrentTransaction.EnlistVolatile(command, EnlistmentOptions.None);
                command.Execute();
                scope.Complete();
            }
        }
        private class TransactionalCommand : Enlistable
        {
            public void Execute()
            { 
                // Do some work here...
            }
            public override void Commit(IEnlistment enlistment)
            {
                enlistment.Done();
            }
            public override void Rollback(IEnlistment enlistment)
            {
                // Do rollback work...
                enlistment.Done();
            }
            public override void Prepare(IPreparingEnlistment enlistment)
            {
                enlistment.Prepared();
            }
            public override void InDoubt(IEnlistment enlistment)
            {
                enlistment.Done();
            }
        }
    }
