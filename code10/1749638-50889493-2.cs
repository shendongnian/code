            int i = 0;
            while(i < 10000)
            {
                try
                {
                    using (TransactionScope scope = new TransactionScope())
                    {
                        var account = dal.GetAccountById(accountId);
                        account.Balance++;
                        dal.Update(account);
                        scope.Complete();
                    }
                    i++;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{ex.Message} : restarting");
                }
            }
