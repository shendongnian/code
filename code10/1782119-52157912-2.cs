    public async Task TestFunction {
        //Arrange
        var helper = MockRepository.GenerateMock<IDBHelper>();
        MyFunction.helper = helper;
        helper.Stub(_ => _.UpgradeDB()).Return(false);
        //...arrange other parameters
        //Act
        var actual = await MyFunction.Run(...);
        //Assert
        //...
    }
