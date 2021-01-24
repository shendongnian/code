    public async Task TestFunction {
        //Arrange
        var helper = MockRepository.GenerateMock<IDBHelper>();        
        MyFunction.helper = helper; //<<--override default helper with mock
        helper.Stub(_ => _.UpgradeDB()).Return(false);//or true is that is what you desire
        //...arrange other parameters / dependencies
        //Act
        var actual = await MyFunction.Run(...);
        //Assert
        //...
    }
