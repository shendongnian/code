    [TestClass]
    public class WebSocketTests {
        [Test]
        public void ConnectedTest() {
            //Arrange
            var webSocketMock = Substitute.For<IWebSocket>();
            
            var subject = new WebsocketClient(webSocketMock);
            bool raised = false;
            subject.Connected += delegate(object sender, EventArgs e) {
                raised = true;
            };
            subject.ConnectAsync();
            //Act
            webSocketMock.OnOpen += Raise.Event();
            //Assert
            Assert.IsTrue(raised);
        }
    }
