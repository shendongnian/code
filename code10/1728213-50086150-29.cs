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
        public void Should_Check_HasFlag_Bitwise() {
            //Arrange
            var fixedSchedult = ScheduleType.Fixed; //Fixed Work Schedule
            var fullTime = ScheduleType.FullTime; // Full Time Work Schedule
            var partTime = ScheduleType.PartTime;
            var value = fixedSchedult | fullTime | partTime;
            //Act
            var actual = value.HasFlag(fullTime | partTime);
            //Assert
            actual.Should().Be(true);
        }
    }
    
