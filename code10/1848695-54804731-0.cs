    [Test]
    public void TestViaVerify()
    {
        ....
        robert.IsEmployed = true; // will make this UT to failed
        //Assert
        dataStore.Verify(x => x.UpdateEmployee(It.Is<Employee>(e => e.IsEmployed == false)), Times.Once);
    }
    [Test]
    public void TestViaSetupVerifyAll()
    {
        ....
        robert.IsEmployed = true; // will make this UT to failed
        //Assert
        dataStore.VerifyAll();
    }
