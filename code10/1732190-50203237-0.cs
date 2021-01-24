    [Fact]
    public void ProjectTest() {
        var ProjectServiceMock = new Mock<IProjectService>();
        var ProjectMock = new Mock<IProject>();
        IProject project = ProjectMock.Object;
        var path = new Path("C:");
        ProjectServiceMock.Setup(x => x.CreateProject(path, "S1")).Returns(project);
        var addProjectViewModel = new AddProjectViewModel(ProjectServiceMock.Object);
        IProjectService obj = ProjectServiceMock.Object;
        var result = obj.CreateProject(path, "S1");
    }
