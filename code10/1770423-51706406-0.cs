    dependency.Setup(d => d.FooAsync()).Returns(Task.CompletedTask);
    var barException = new Exception("Bar Error");
    dependency.Setup(d => d.BarAsync()).Returns(Task.FromException(barException ));
    systemUnderTest.Awaiting(sut => sut.DoStuffAsync())
                   .Should().Throw<Exception>()
                   .WithMessage("Bar Error");
