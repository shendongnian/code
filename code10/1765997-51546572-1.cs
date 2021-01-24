    [Fact]
    public async virtual Task Test_Exception() {
        //Arrange
        var queryString = "SELECT * FROM c";
        //Act
        var exception = await Record.ExceptionAsync(() =>
            classname.RunSQLQueryAsync(queryString));
        //Assert
        Assert.NotNull(exception);
        Assert.IsType<InvalidOperationException>(exception);
    }
