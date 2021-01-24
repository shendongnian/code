    public class AccountServiceTests {
           
        [Test]
        public void UpdateProfile_Should_Return_Salary() {
            //Arrange
            var accountRepository = MockRepository.GenerateMock<IAccountRepository>(); 
            var service = new AccountService(accountRepository);
            var userId = 123;
            decimal salary = 1000M;
            var expected = 1000;
            accountRepository.Expect(_ => _.UpdateProfile(userId, salary)).Return(expected);
            //Act
            var updatedSalary = service.UpdateProfile(userId, salary);
            //Assert
            Assert.AreEqual(expected, updatedSalary);
        }
    }
