    [TestFixture] public class ByteSize
    {
        [TestCase(0, Result="0 B")]
        [TestCase(1, Result = "1 B")]
        [TestCase(1000, Result = "1 KB")]
        [TestCase(1500000, Result = "1.5 MB")]
        [TestCase(-1000, Result = "-1 KB")]
        [TestCase(int.MaxValue, Result = "2.1 GB")]
        [TestCase(int.MinValue, Result = "-2.1 GB")]
        [TestCase(long.MaxValue, Result = "9.2 EB")]
        [TestCase(long.MinValue, Result = "-9.2 EB")]
        public string Format_byte_size(long size)
        {
            return Format.ByteSize(size);
        }
    }
