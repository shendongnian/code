        [Test]
        public void testConvertFromUnicode()
        {
            
            char myValue = Char.Parse("\u0D15");
            Assert.AreEqual(3349, myValue);
            char unicodeChar = '\u0D15';
            string unicodeString = Char.ConvertFromUtf32(unicodeChar);
            Assert.AreEqual(1, unicodeString.Length);
            char[] charsInString = unicodeString.ToCharArray();
            Assert.AreEqual(1, charsInString.Count());
            Assert.AreEqual((int) '\u0D15', charsInString[0]);
        }
