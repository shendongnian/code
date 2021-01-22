    [TestFixture]
    public class CustomReferenceTests
    {
        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void TestParsingCustomReferenceWithInValidSecondsFromMidnight()
        {
            // I am expecting this method to throw an ArgumentException:
            CustomReference.Parse("010100712386401000000012");
        }
        [Test]
        [ExpectedException(typeof(ArgumentException), ExpectedMessage = "Seconds from midnight cannot be more than 86400 in 010100712386401000000012")]
        public void TestParsingCustomReferenceWithInValidSecondsFromMidnightWithExpectedMessage()
        {
            // I am expecting this method to throw an ArgumentException:
            CustomReference.Parse("010100712386401000000012");
        }
    }
    public class CustomReference
    {
        public static void Parse(string s)
        {
            throw new ArgumentException("Seconds from midnight cannot be more than 86400 in 010100712386401000000012");
        }
    }
