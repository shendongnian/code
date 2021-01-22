    public class TestableBLLClass : BLLClass
        {
            public bool scopeCalled;
            protected override TransactionScope GetTransactionScope()
            {
                this.scopeCalled = true;
                return base.GetTransactionScope();
            }
        }
