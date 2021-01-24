    public void StudentGetAllTestReturnsStudents() {
        //Arrange
        var fakeStudents = new List<Student>() { //used actual list instead of mock
            new Student() {  }
        };
        _mockRepository
            .Setup(_ => _.GetAll(It.IsAny<StudentFilter>()))
            .Returns(fakeStudents);
        _studentController = new StudentsController(_mockRepository.Object);
        Mapper.Initialize(cfg => {
            cfg.CreateMap<FilterRequst, StudentFilter>();
        });
        // Act
        var actionResult = _studentController.Get(new FilterRequst());//use actual model
        var result = actionResult as ObjectResult;
        var model = result.Value as StudentListModel;
        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(StatusCodes.Status200OK, result.StatusCode);
        Assert.IsNotNull(model);
    }
