    bool isTransactionComplete = true;
                try
                {
                    using (TransactionScope trScope = new TransactionScope(TransactionScopeOption.Required))
                    {
                        //some work
                        trScope.Complete();
                    }
                }
                catch (TransactionAbortedException e)
                {
                    //Transaction holder got exception from some service
                    //and canceled transaction
                    isTransactionComplete = false;
                }
                catch//other exception
                {
                    isTransactionComplete = false;
                    throw; 
                }
                if (isTransactionComplete)
                {
                    //Success 
                }
