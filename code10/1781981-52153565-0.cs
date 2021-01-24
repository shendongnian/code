    [TestClass]
    public class MySvcTests {
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public async Task DoBusinessLogic_If2ndObjectNotExist_ThrowException() {
            var _repoMock = new Mock<IMyRepo>() { };
            var _connectorMock = new Mock<IMyConnectorClass>();
            _repoMock.Setup(r => r.GetConnector()).Returns(_connectorMock.Object);
            var _svc = new MySvc(_repoMock.Object);
            // This should return an object
            _repoMock.Setup(r => r.GetObjectByIdAsync<Foo>(It.IsAny<int>(), _connectorMock.Object))
                .ReturnsAsync(new Foo());
            // This should return null
            _repoMock.Setup(r => r.GetObjectByIdAsync<Bar>(It.IsAny<int>(), _connectorMock.Object))
                .ReturnsAsync((Bar)null);
            await _svc.DoBusinessLogic(0, 0);
        }
    }
