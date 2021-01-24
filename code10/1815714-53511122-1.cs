    [TestFixture]
    public class Test
    {
        [Test]
        [TestCase("CATEGORY:    SIDES   DATE CREATED:   03/12/16", "CATEGORY:            DATE CREATED:           ")]
        [TestCase("PRODUCT:      CARROTS    DATE DELETED:    05/11/17", "PRODUCT:                 DATE DELETED:            ")]
        public void TestMethod(string input, string expectedResult)
        {
            //arrange
            var uut = new WordStripper();
    
            //act
            var actualResults = uut.StripWords(input);
    
            //assert
            Assert.AreEqual(expectedResult, actualResults);
        }
    }
