    public class TrainUnitTest
    {
        [Fact]
        public void Should_Get_TrainID()
        {
            //arrange
            var expected = "1S45";
            var subject  = new Train("1S45");
    
            //act
            string actual = subject.TrainID;
    
            //assert
            Assert.Equal(expected, actual);
        }
    }
