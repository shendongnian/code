    [Fact]
    public void RoundTrippingWorks()
    {
        var fixture = new Fixture().Customize(/*...*/);
        var model = fixture.Create<MyModel>();
    
        string xml = MyXmlSerializer.Serialize(model);
        MyModel actual = MyXmlParser.Parse(xml);
    
        Assert.Equal(model, actual);
    }
