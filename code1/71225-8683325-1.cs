    [TestFixture]
    public class RandomStringTest
    {
        [Test]
        public void GetAsciiStringTest()
        {
            int expectedLenght = 5;
            Encoding expectedEncoding = new ASCIIEncoding();
            string actual = RandomString.GetRandomString(expectedLenght, expectedEncoding);
            Assert.AreEqual(expectedLenght, actual.Length);
        }
    
        [Test]
        public void GetUTF16StringTest()
        {
            int expectedLenght = 10;
            Encoding expectedEncoding = new UnicodeEncoding();
            string actual = RandomString.GetRandomString(expectedLenght, expectedEncoding);
            //uses two bytes in Unicode (which is UTF-16)
            Assert.AreEqual(expectedLenght / 2, actual.Length);
        }
    
        [Test]
        public void GetUTF8StringTest()
        {
            int expectedLenght = 10;
            Encoding expectedEncoding = new UTF8Encoding();
            string actual = RandomString.GetRandomString(expectedLenght, expectedEncoding);
            Assert.AreEqual(expectedLenght, actual.Length);
        }
    
        [Test]
        public void GetUTF7StringTest()
        {
            int expectedLenght = 10;
            Encoding expectedEncoding = new UTF7Encoding();
            string actual = RandomString.GetRandomString(expectedLenght, expectedEncoding);
            Assert.AreEqual(expectedLenght, actual.Length);
        }
    
        [Test]
        public void GetUTF32StringTest()
        {
            int expectedLenght = 128;
            Encoding expectedEncoding = new UTF32Encoding();
            string actual = RandomString.GetRandomString(expectedLenght, expectedEncoding);
            //uses four bytes in UTF-32
            Assert.AreEqual(expectedLenght / 4, actual.Length);
        }
    }
