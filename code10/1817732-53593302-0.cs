    [TestMethod]
    public void TestMethod1()
    {
        // Arrange
        var DialogServiceMock = new Mock<IDialogService>();
        var ViewModelFactoryMock = new Mock<IViewModelFactory>();
        var viewModel = Mock.Of<EditViewModel>(); // Or new EditViewModel(...);
        ViewModelFactoryMock
            .Setup(_ => _.CreateEditViewModel(It.IsAny<Argument1>(),....));
            .Returns(viewModel);
        DialogServiceMock
            .Setup(x => x.ShowDialog(It.IsAny<EditViewModel>()))
            .Returns(true)
            .Verifiable();
        MainWindowViewModel vm = new MainWindowViewModel(DialogServiceMock.Object, ViewModelFactoryMock.Object);
        // Act
        vm.OpenEditView();
        // Assert
        //verify that the mocked view model was actually used.
        DialogServiceMock.Verify(mock => mock.ShowDialog(viewModel));
    }
