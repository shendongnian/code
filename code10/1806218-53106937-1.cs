	[Test]
	[TestCase(10)]
	[TestCase(-100)]
	[TestCase(Int32.MinValue)]
	public void GivenATestWithValueLessOrEqualThan10_ThenValueDescriptionShouldBeNull(int value)
	{
		// arrange
		var mockTest = new Test(value);
		// act/assert
		Assert.That(mockTest.ValueDescription, Is.Null);
	}
