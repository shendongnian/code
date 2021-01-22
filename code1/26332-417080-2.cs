       using System.Transactions;
        
        class Foo
        {   
            void Bar()
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    // Data access
                    // ...
                    scope.Complete()
                }
            }
        }
