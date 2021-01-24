	[TestClass]
	public class UnitTest1 {
		[TestMethod]
		public void GetInvestmentAccountsTest() {
		    //Arrange
			var clientId = 25;
			var mockAccounts = new List<Account> {
				new Account{AccountNumber = "aaa", AccountOwner = clientId, AccountType = AccountType.Investment},
				new Account{AccountNumber = "bbb", AccountOwner = clientId, AccountType = AccountType.Savings},
				new Account{AccountNumber = "ccc", AccountOwner = clientId, AccountType = AccountType.Checking},
			};
			var mockDatastore = new Mock<IDataStore>();
			mockDatastore.Setup(_ => _.LoadAccounts(clientId)).Returns(mockAccounts);
			var subject = new AccountBl(mockDatastore.Object);
			//Act
			var accounts = subject.GetInvestmentAccounts(clientId, AccountType.Investment);
			//Assert
			//...
		}
	}
