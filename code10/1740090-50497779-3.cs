    using Moq;
    using Xunit;
    
    public class ServiceStationTests
    {
        [Fact]
        public void OpenForService_should_be_called_once()
        {
            // Arrange
            var mockGateUtility = new Mock<IGateUtility>();
            mockGateUtility.Setup(x => x.OpenGate());
    
            // Act
            var sut = new ServiceStation(mockGateUtility.Object);
            sut.OpenForService();
    
            // Assert
            mockGateUtility.Verify(x => x.OpenGate(), Times.Once);
        }
    
        [Fact]
        public void CloseForDay_should_be_called_once()
        {
            // Arrange
            var mockGateUtility = new Mock<IGateUtility>();
            mockGateUtility.Setup(x => x.CloseGate());
    
            // Act
            var sut = new ServiceStation(mockGateUtility.Object);
            sut.CloseForDay();
    
            // Assert
            mockGateUtility.Verify(x => x.CloseGate(), Times.Once);
        }
    }
