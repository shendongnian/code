    [Test]
    public void IWantToRegisterANewUser()
    {
      ICustomer customer = new Customer();
      SoThat(MyBusinessValue.IncreaseCustomerBase)
        .As(new User())
        .Given(customer.Register)
        .When(customer.Confirm_Registration)
        .Then(customer.Login);
    }
