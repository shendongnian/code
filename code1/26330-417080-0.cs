       using System.Transactions;
        
        class Foo
        {   
            void Bar()
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    scope.Complete()
                }
            }
        }
