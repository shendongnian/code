    [Test]
    public void EmptylListTest()
    {
        var repositoryMock = new Mock<ICustomerRepository>();
        IEnumerable<Customer> customers = repositoryMock.Object.GetCustomers();
        Assert.IsNotNull(customers);
        Assert.AreEqual(0, customers.Count());
    }
    [Test]
    public void EmptyArrayTest()
    {
        var repositoryMock = new Mock<ICustomerRepository>();
        Customer[] customerArray = repositoryMock.Object.GetCustomerArray();
        Assert.IsNotNull(customerArray);
        Assert.AreEqual(0, customerArray.Length);
    }
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetCustomers();
        Customer[] GetCustomerArray();
    }
