    [TestClass]
    public class LoanEligibilityTest
    {        
        [TestMethod]
        public void TestLoanTypePersonal()
        {
            //Arrange
            ILoanEligibility loanEligibility = new LoanEligibility(); // actual implementation
            string loanType = "Personal";
            //Act
            bool expected = _loanEligibility.HasCorrectType(loanType);
            //Assert
            Assert.IsTrue(expected);
        }
    }
