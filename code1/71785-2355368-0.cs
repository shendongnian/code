    var mock = new Mock<IFoo>();
    bool called=false;
    string test=string.empty; 
    mock.Setup(foo => foo.Execute(It.IsAny<string>())).Callback((string s) => { test = s; called = true;});
    Assert.IsTrue(called, "Execute() was not called");
