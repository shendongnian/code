    [Test]
    public void WriteToDBShouldWrite()
    {
        var mockObject = new Mock<INameGetter>();
        mockObject.Setup(x =>  x.GetName()).Returns(Task.FromResult("Frank"));
        string result =  new Employee(mockObject.Object).WriteNameToDataBase();
        Assert.AreEqual("Wrote Frank to database", result);
    }
