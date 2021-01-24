	[Test]
	[TestCase(12)]
	[TestCase(100)]
	[TestCase(Int32.MaxValue)]
	public void GivenATestWithValueBiggerThan10_ThenValueDescriptionShouldBeEqualsAsExpected(int value)
	{
		// arrange
		var mockTest = new Test(value);
		// act/assert
		Assert.That(mockTest.ValueDescription, Is.EqualTo("Value bigger than 10"));
	}
