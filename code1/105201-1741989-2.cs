    [TestFixture]
    public class RangeSplitterTests
    {
        [Test]
        public void Split_NullString_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var result = RangeSplitter.Split(null);
            });
        }
        [Test]
        public void Split_EmptyString_ReturnsEmptyArray()
        {
            Range[] result = RangeSplitter.Split(String.Empty);
            Assert.That(result.Length, Is.EqualTo(0));
        }
        [Test]
        public void Split_SingleNumber_ProducesRangeOfThatNumber()
        {
            Range[] result = RangeSplitter.Split("7");
            Assert.That(result.Length, Is.EqualTo(1));
            Assert.That(result[0].ToString(), Is.EqualTo("7"));
        }
        [Test]
        public void Split_SingleNumberUp_ProducesRangeOfThatNumberAndUp()
        {
            Range[] result = RangeSplitter.Split("7++");
            Assert.That(result.Length, Is.EqualTo(1));
            Assert.That(result[0].ToString(), Is.EqualTo("7++"));
        }
        [Test]
        public void Split_SingleNumberDown_ProducesRangeOfThatNumberAndDown()
        {
            Range[] result = RangeSplitter.Split("++7");
            Assert.That(result.Length, Is.EqualTo(1));
            Assert.That(result[0].ToString(), Is.EqualTo("++7"));
        }
        [Test]
        public void Split_Range_ProducesRange()
        {
            Range[] result = RangeSplitter.Split("1++7");
            Assert.That(result.Length, Is.EqualTo(1));
            Assert.That(result[0].ToString(), Is.EqualTo("1++7"));
        }
        [TestCase(01, "++7")]
        [TestCase(02, "7++")]
        [TestCase(03, "1++7")]
        [TestCase(04, "1+7")]
        [TestCase(05, "1++7+10++15+20+30++")]
        public void Split_ExamplesFromQuestion_ProducesCorrectResults(
            Int32 testIndex, String input)
        {
            Range[] ranges = RangeSplitter.Split(input);
            String rangesAsString = String.Join("+",
                ranges.Select(r => r.ToString()).ToArray());
            Assert.That(rangesAsString, Is.EqualTo(input));
        }
        [TestCase(01, 10, 10, "10")]
        [TestCase(02, 1, 10, "1++10")]
        [TestCase(03, Int32.MinValue, 10, "++10")]
        [TestCase(04, 10, Int32.MaxValue, "10++")]
        public void RangeToString_Patterns_ProducesCorrectResults(
            Int32 testIndex, Int32 lower, Int32 upper, String expected)
        {
            Range range = new Range(lower, upper);
            Assert.That(range.ToString(), Is.EqualTo(expected));
        }
    }
