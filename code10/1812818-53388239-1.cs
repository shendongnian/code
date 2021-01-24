    [Theory]
    [InlineData("Value1")]
    [InlineData("Value2")]
    [InlineData("Value3")]
    [InlineData(null)]
    public void SearchDemo_DbHandlerContainsModelField1_WhenField1IsContained(string field1)
    {
        //Arrange
        var model = new DemoViewModel();
        model.Field1 = field1;
        
        //Your stuff
    }
