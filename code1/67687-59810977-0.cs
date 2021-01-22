    public static string ToFileLengthRepresentation(this long fileLength)
    {
        if (fileLength >= 1 << 30)
            return $"{fileLength >> 30}Gb";
            
        if (fileLength >= 1 << 20)
            return $"{fileLength >> 20}Mb";
            
        if (fileLength >= 1 << 10)
            return $"{fileLength >> 10}Kb";
        return $"{fileLength}B";
    }
    [TestFixture]
    public class NumberExtensionsTests
    {
        [Test]
        [TestCase(1024, "1Kb")]
        [TestCase(2048, "2Kb")]
        [TestCase(2100, "2Kb")]
        [TestCase(700, "700B")]
        [TestCase(1073741824, "1Gb")]
        public void ToFileLengthRepresentation(long amount, string expected)
        {
            amount.ToFileLengthRepresentation().ShouldBe(expected);
        }
    }
