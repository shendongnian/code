        [TestCase(null, ExpectedResult = "")]
        [TestCase("", ExpectedResult = "")]
        [TestCase("ABC", ExpectedResult = "ABC")]
        [TestCase("abc", ExpectedResult = "abc")]
        [TestCase("camelCase", ExpectedResult = "camel Case")]
        [TestCase("PascalCase", ExpectedResult = "Pascal Case")]
        [TestCase("Pascal123", ExpectedResult = "Pascal 123")]
        [TestCase("CustomerID", ExpectedResult = "Customer ID")]
        [TestCase("CustomABC123", ExpectedResult = "Custom ABC123")]
        public string CanSplitCamelCase(string input)
        {
            return FromCamelCaseToSentence(input);
        }
