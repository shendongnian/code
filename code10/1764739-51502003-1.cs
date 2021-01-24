    [TestFixture]
    public sealed class FetchingTest
    {
        private Mock<IServiceBus> mockIServiceBus;
        private Mock<IQueueClient> queueClient1;
        [TestFixtureSetUp]
        public void Setup() {
            this.mockIServiceBus = new Mock<IServiceBus>();
            this.queueClient1 = new Mock<IQueueClient>();
        }
        [Test]
        public void TestPagingUsesCorrectOffsets() {
            //Arrange
            this.mockIServiceBus
                .Setup(_ => _.GetQueueClient(Constants.FetcherQueueName))
                .Returns(queueClient1.Object);
            //...
        }
    }
