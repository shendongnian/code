    [TestFixture]
    public class MoqTests
    {
        [Test]
        public void MoqOutParameter()
        {
            // Arrange
            Mock<ISample> mockSample = new Mock<ISample>();
            Key MyKey = new Key(DateTime.Today, "SomeValue");
            SampleOutput sampleOut = new SampleOutput() { prop2 = 2 };
            mockSample.Setup(s => s.SampleMethod(It.Is<Key>(t => t.Equals(MyKey)),
                out sampleOut)).Returns(true);
            // Act  
            SampleOutput out1;
            var result1 = mockSample.Object.SampleMethod(new Key(DateTime.Today, "SomeValue"), out out1);
            SampleOutput out2;
            var result2 = mockSample.Object.SampleMethod(new Key(DateTime.MinValue, "AnotherValue"), out out2);
            // Assert
            Assert.True(result1);
            Assert.AreEqual(out1, sampleOut);
            Assert.False(result2);
            Assert.Null(out2);
        }
    }
    public class Key
    {
        public readonly DateTime prop1;
        public readonly string prop2;
        public Key(DateTime prop1, string prop2)
        {
            this.prop1 = prop1;
            this.prop2 = prop2;
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            Key other = obj as Key;
            // was forced to add `== 0` to make it compilable
            return this.prop1 == other.prop1 && string.Compare(this.prop2, other.prop2) == 0;
        }
        public override int GetHashCode()
        {
            return prop1.GetHashCode() ^ prop2.GetHashCode();
        }
    }
    public class SampleOutput
    {
        public int prop2 { get; set; }
    }
    public interface ISample
    {
        bool SampleMethod(Key key, out SampleOutput sampleOut);
    }
