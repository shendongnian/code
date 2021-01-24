    [Fact]
    public void ProjectTest() {
        var ProjectServiceMock = new Mock<IProjectService>();
        var ProjectMock = new Mock<IProject>();
        IProject project = ProjectMock.Object;
        ProjectServiceMock.Setup(x => x.CreateProject(It.IsAny<Path>(), "S1")).Returns(project);
        var addProjectViewModel = new AddProjectViewModel(ProjectServiceMock.Object);
        IProjectService obj = ProjectServiceMock.Object;
        var result = obj.CreateProject(new Path("C:"), "S1");
    }
