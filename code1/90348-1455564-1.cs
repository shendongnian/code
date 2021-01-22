    [Test]
    public void Can_Update_Account() {
			Account account = PersistenceContext.Get<Account>(TEST_ACCOUNT_ID);
			string accountNumber = RandomString(10);
			account.AccountNumber = accountNumber;
			Account account1 = PersistenceContext.GetAll<Account>().Where(x => x.AccountNumber == accountNumber).SingleOrDefault();
			Account account2 = PersistenceContext.Get<Account>(account.Id);
			Assert.AreEqual(account.Id, account1.Id);
			Assert.AreEqual(accountNumber, account2.AccountNumber);
		}
