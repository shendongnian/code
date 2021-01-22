    [TestCase("1", 1)]
    [TestCase("0", 0)]
    [TestCase("-1", -1)]
    [TestCase("2147483647", int.MaxValue)]
    [TestCase("2147483648", null)]
    [TestCase("-2147483648", int.MinValue)]
    [TestCase("-2147483649", null)]
    [TestCase("1.2", null)]
    [TestCase("1 1", null)]
    [TestCase("", null)]
    [TestCase(null, null)]
    [TestCase("not an int value", null)]
    public void Should_parse_input_as_nullable_int(object input, int? expectedResult)
    {
    	int? parsedValue;
    			
    	bool parsingWasSuccessfull = input.TryParse(out parsedValue);
    
    	Assert.That(parsingWasSuccessfull);
    	Assert.That(parsedValue, Is.EqualTo(expectedResult));
    }
