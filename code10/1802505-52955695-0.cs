        public class UnitTest
    {
        [Fact]
        public void TestList()
        {
            var sample = new SampleList
            {
                Fields = { "b", "c" }
            };
            var count = sample.Fields.Count;
            Assert.Equal(2, count);
        }
        [Fact]
        public void TestArray()
        {
            var sample = new SampleArray
            {
                Fields = { "b", "c" }
            };
            var count = sample.Fields.Count;
            Assert.Equal(2, count);
        }
    }
    public class SampleList
    {
        public ICollection<string> Fields { get; set; } = new List<string>
        {
            "a"
        };
    }
    public class SampleArray
    {
        public ICollection<string> Fields { get; set; } = new string[]
        {
            "a"
        };
    }
