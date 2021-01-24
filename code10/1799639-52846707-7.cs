    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var obj = new SomeScriptOnGameObject();
            Assert.True(obj.Property("FirstVariable").IsWritable());
            Assert.False(obj.Property("SecondVariable").IsWritable());
            Assert.False(obj.Field("Field").IsWritable());
            Assert.Equal("First Variable", obj.Property("FirstVariable").DisplayName());
            Assert.Equal("Second Variable", obj.Property("SecondVariable").DisplayName());
            Assert.Equal("Some Field", obj.Field("Field").DisplayName());
            Assert.Null(obj.Field("FieldWithNoAttributes").DisplayName());
        }
    }
