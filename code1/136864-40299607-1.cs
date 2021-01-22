        using (var date = DateTimeProvider.InjectActualDateTime(expectedDateTime)) 
        { 
            var bankAccount = new BankAccount(); 
 
            bankAccount.DepositMoney(600); 
 
            var lastTransaction = bankAccount.Transactions.Last(); 
 
            Assert.IsTrue(expectedDateTime.Equals(bankAccount.Transactions[0].TransactionDate)); 
        } 
