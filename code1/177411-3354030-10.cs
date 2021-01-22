    [Test]
    public void GetAll_Should_Call_GetAll_On_Repository_Test() {
      var testRepository = new TestRepository();
      var orderManager = new Manager<Order>(testRepository);
      // test an orderManager method
      orderManager.GetAll();
      // use testRepository to verify (sense) that the orderManager method worked
      Assert.IsTrue(testRepository.GetAllCalled);
    }
