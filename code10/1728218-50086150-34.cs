    [TestClass]
    public class ScheduleTypeValueObjectTests {
        [TestMethod]
        public void Should_Merge_Names() {
            //Arrange
            var fixedSchedult = ScheduleType.Fixed; //Fixed Work Schedule
            var fullTime = ScheduleType.FullTime; // Full Time Work Schedule
            var type = fixedSchedult | fullTime;
            //Act
            var actual = type.Name;
            //Assert
            actual.Should().Be("Fixed, Full Time Work Schedule");
        }
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Should_Fail_Bitwise_Combination() {
            //Arrange
            var fullTime = ScheduleType.FullTime; // Full Time Work Schedule
            var partTime = ScheduleType.PartTime;
            var value = fullTime | partTime;
        }
    }
    
