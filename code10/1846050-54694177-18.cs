    [Test]
    //note this is also async now
    public async Task WriteToDBShouldWrite()
    {
        var mockObject = new Mock<INameRepo>();
        mockObject.Setup(x => x.GetName()).ReturnsAsync("Frank");
        string result = mockObject.Object.WriteNameToDataBase();
        Employee emp = new Employee(mockObject.Object);
        await emp.WriteToDBShouldWrite();
        //ensure GetName is called once and once only
        mockObject.Verify(v => v.GetName(), TimesOnce);
    }
