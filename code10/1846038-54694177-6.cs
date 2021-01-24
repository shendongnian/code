    [Test]
    //note this is also async now
    public async Task WriteToDBShouldWrite()
    {
        var mockObject = new Mock<INameRepo>();
        mockObject.Setup(x => x.GetName()).ReturnsAsync("Frank");
        string result = mockObject.Object.WriteNameToDataBase();
        //test the actual object
        Employee emp = new Employee(mockObject.Object);
        string result = await emp.WriteToDBShouldWrite();
        Assert.AreEqual("Wrote Frank to database", result);
    }
