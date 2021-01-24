    [TestClass]
    public class AwsTests {
        [Test]
        public void Should_Throw_For_Null_TableName() {
            //Arrange
            var subject = new SubjectUnderTest(null);
            ArgumentNullException exception = null;
            var expected = "tableName";
            //Act
            try {
                subject.BatchSave<object>(null, null);
            } catch (ArgumentNullException e) {
                exception = e;
            }
            //Assert
            exception.Should().NotBeNull();
            exception.ParamName.Should().Be(expected);
        }
        [Test]
        public void Should_Throw_For_Null_Items() {
            //Arrange
            var subject = new SubjectUnderTest(null);
            ArgumentNullException exception = null;
            var expected = "items";
            //Act
            try {
                subject.BatchSave<object>("fakeTableName", null);
            } catch (ArgumentNullException e) {
                exception = e;
            }
            //Assert
            exception.Should().NotBeNull();
            exception.ParamName.Should().Be(expected);
        }
    }
