    [Fact]
    public void ProjectTest() {
        //Arrange
        var ProjectServiceMock = new Mock<IProjectService>();
        var ProjectMock = new Mock<IProject>();
        IProject project = ProjectMock.Object;
        ProjectServiceMock
            .Setup(x => x.CreateProject(It.IsAny<Path>(), "S1"))
            .Returns(project);
        //System under test
        var addProjectViewModel = new AddProjectViewModel(ProjectServiceMock.Object);
        //Act
        addProjectViewModel.SomeMethodToTest();
        //...assumption is that `CreateProject(new Path("C:"), "S1")` will get called within
        //...the method under test
        //Assert
        //...now assert expected behavior        
    }
