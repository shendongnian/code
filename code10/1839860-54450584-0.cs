    ...
    [TestMethod]
    public void CanWithdraw_AccountIsEmpty_ReturnsFalse()
    {
        var person = new Person("John", "Smith");
        var account = new BankAccount(person, 0.00);
        var result = account.CanWithdraw();
        
        Assert.IsFalse(result);
    }
