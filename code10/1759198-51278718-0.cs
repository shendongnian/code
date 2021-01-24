    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    
    namespace UnitTestProject1
    {
        public class Vehicle{}
        public interface IVehicleMake
        {
            Vehicle Make();
        }
        public interface IVehicleMakeRepository
        {
            Task<IList<IVehicleMake>> GetAllMakes();
        }
    
        public class MyService
        {
            private readonly IVehicleMakeRepository vehicleMakeRepository;
    
            public MyService(IVehicleMakeRepository vehicleMakeRepository)
            {
                this.vehicleMakeRepository = vehicleMakeRepository;
            }
    
            public async Task DoSomething()
            {
                var makes = await vehicleMakeRepository.GetAllMakes();
                foreach (var make in makes)
                {
                    var vehicule = make.Make();
                }
            }
        }
    
        public class MyServiceTest
        {
            [TestClass]
            public class DoSomething
            {
                [TestMethod]
                public async Task Should_CallAllMakersOnce()
                {
                    //Arrange
                    var mockedMakers = new[] { new Mock<IVehicleMake>(), new Mock<IVehicleMake>(), };
                    foreach (var mockedMaker in mockedMakers)
                    {
                        mockedMaker.Setup(m => m.Make()).Returns(new Vehicle()).Verifiable();
                    }
                    var mockedRepository = new Mock<IVehicleMakeRepository>();
                    mockedRepository
                        .Setup(m => m.GetAllMakes())
                        .ReturnsAsync(mockedMakers.Select(mm => mm.Object).ToList())
                        .Verifiable();
                    var service = new MyService(mockedRepository.Object);
                    //Act
                    await service.DoSomething();
                    //Assert
                    mockedRepository.Verify(m => m.GetAllMakes(), Times.Once);
                    foreach (var mockedMaker in mockedMakers)
                    {
                        mockedMaker.Verify(m => m.Make(), Times.Once);
                    }
                }
            }
        }
    }
