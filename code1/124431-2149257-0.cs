    [TestMethod]
    public void TestThatSomethingHappens()
    {
        var repo = new Mock<IRepository>();
        repo.Setup(x => x.Find<Customer>(It.IsAny<int>())).Returns(_somePredefinedCustomer);
        // etc.
    }
