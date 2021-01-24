    public class UnitTest
    {
        [Fact]
        public void Test1()
        {
            var serviceMock = new Mock<IService>();
            serviceMock.SetupSequence(s => s.MethodB(It.IsAny<List<object>>()))
                .Returns(new List<int>());
            var service = serviceMock.Object;
            Assert.NotNull(service.MethodB(new List<object>()));
            Assert.Null(service.MethodB(new List<object>()));
        }
    }
    public interface IService
    {
        List<int> MethodB(List<object> objects);
    }
