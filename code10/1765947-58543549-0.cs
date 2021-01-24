    [Theory]
    [ClassData(typeof(FooDataGenerator))]
    public void FooWithFilter(string fooId, decimal? expected)
    {
        // Arrange // Act // Assert
    }
    
    public FooDataGenerator : TheoryData<string, decimal?>
    {
        public FooDataGenerator()
        {
            this.Add("987", null);
            this.Add("123", 610m};
            // ...
        }
    }
