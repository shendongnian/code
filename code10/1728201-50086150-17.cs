    [TestClass]
    public class ScheduleTypeValueObjectTests {
        [TestMethod]
        public void Should_Merge_DisplayNames() {
            //Arrange
            var fixedSchedult = ScheduleType.Fixed; //Fixed Work Schedule
            var fullTime = ScheduleType.FullTime; // Full Time Work Schedule
            var type = fixedSchedult.And(fullTime); 
            //Act
            var actual = type.Name;
            //Assert
            actual.Should().Be("Fixed, Full Time Work Schedule");
        }
    }
    
