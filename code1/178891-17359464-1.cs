    [TestFixture]
	public class ObjectExtensionsTester
	{
		[TestCase("true", true)]
		[TestCase("True", true)]
		[TestCase("false", false)]
		[TestCase("False", false)]
		[TestCase(null, null)]
		[TestCase("not a boolean value", null)]
		public void Should_parse_input(object input, bool? expectedResult)
		{
			bool? parsedValue;
			
			bool parsingWasSuccessfull = input.TryParse(out parsedValue);
			Assert.That(parsingWasSuccessfull);
			Assert.That(parsedValue, Is.EqualTo(expectedResult));
		}
	}
