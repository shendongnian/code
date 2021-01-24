    [Test]
    public async Task ShouldCatchException()
    {
        // Arrange
        var foo = Substitute.For<IFoo>();
        foo.DoSomething().Throws(new Exception());
        var bar = new Bar(foo);
        // Act
        int? result = null;
        Func<Task> act = async () => result = await bar.DoSomethingSmart();
        // Act-Assert
        await act.Should().NotThrowAsync();
        result.Should().Be(17);
    }
