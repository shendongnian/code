        [TestCase("Start Date", "StartDate")]
        [TestCase("Bad*chars", "BadChars")]
        [TestCase("   leading ws", "LeadingWs")]
        [TestCase("trailing ws   ", "TrailingWs")]
        [TestCase("class", "Class")]
        [TestCase("int", "Int")]
        [Test]
        public void CSharp_GeneratesDecentIdentifiers(string input, string expected)
        {
            Assert.AreEqual(expected, CSharp.Identifier(input));
        }
