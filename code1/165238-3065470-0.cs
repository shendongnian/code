    [TestMethod]
    public void CanGetCustomerByDifId() {
        var customer = this.TestCustomer;
        var repository = Stub<ICustomerRepository>();
        repository.Stub(rep => rep.GetCustomerByDifID(customer.DifID))
                  .Return(customer);
        Assert.AreEqual(customer, repository.GetCustomerByDifID(customer.DifID));
    }
