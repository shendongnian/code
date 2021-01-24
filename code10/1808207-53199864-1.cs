    [Test]
	public void Should_Throw() {
		var classToTest = new TestClass();
		var action = () => classToTest.MethodToTest();
		action.Should().Throw<InvalidOperationException>();
	}
