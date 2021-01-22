    [TestMethod]
    public void Bar_InvalidDependency_ThrowsInvalidOperationException()
    {
		// Expectations
		InvalidOperationException expectedException = null;
		string expectedExceptionMessage = "Bar did something invalid.";
		// Arrange
		IDependency dependency = DependencyMocks.Create();
		Foo foo = new Foo(dependency);
		// Act
		try
		{
			foo.Bar();
		}
		catch (InvalidOperationException ex)
		{
			expectedException = ex;
		}
		// Assert
		Assert.IsNotNull(expectedException);
		Assert.AreEqual(expectedExceptionMessage, expectedException.Message);
	}
