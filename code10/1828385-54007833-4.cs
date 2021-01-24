    var controller = GetSampleController();
    var commadMock = new Mock<ICommand>();
    // How to setup moq here?
    commadMock.Setup(s => s.GetMoviesAsync()).Returns(Task.FromResult<IEnumerable<Movie>>(MovieList())).Verifiable();
 
