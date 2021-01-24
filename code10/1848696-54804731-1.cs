    ....
    var invokedCorrectly = false;
    dataStore.Setup(x => x.UpdateEmployee(It.Is<Employee>(e => e.IsEmployed == false)))
             .Callback<Employee>(x=> invokedCorrectly = true);
    //Act
    FireEmployee(dataStore.Object, robert);
    //Assert
    Assert.IsTrue(invokedCorrectly);
