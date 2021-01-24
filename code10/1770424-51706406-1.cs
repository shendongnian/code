    static Task CreateCompletedTask() 
    {
        return Task.FromResult(default(object));
    }
    static Task CreateTaskWith(Exception exception) 
    {
        var taskSource = new TaskCompletionSource<object>();
        taskSource.SetException(exception);
        return taskSource.Task;
    }
    dependency.Setup(d => d.FooAsync()).Returns(CreateCompletedTask());
    var barException = new Exception("Bar Error");
    dependency.Setup(d => d.BarAsync()).Returns(CreateTaskWith(barException));
    systemUnderTest.Awaiting(sut => sut.DoStuffAsync())
                   .Should().Throw<Exception>()
                   .WithMessage("Bar Error");
