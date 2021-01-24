    public class ConnectorTest
    {
        private readonly Connector _connector;
        private readonly TimerMock _receiverMock;
        private readonly TimerMock _senderMock;
        private readonly LoggerMock _loggerMock;
        private readonly ClientListenerMock _listenerMock;
        public void Setup()
        {
            _listenerMock = new ClientListenerMock();
            _receiverMock = new TimerMock();
            _senderMock  = new TimerMock();
            _loggerMock = new LoggerMock();
            _connector = new Connector(_listenerMock, _receiverMock, _senderMock, _loggerMock)
        }
        public void HeartbeatSender_ShouldBeEnabled_OnceClientIsConnected()
        {
            _listenerMock.SimulateClientConnection();
            Assert.IsTrue(_senderMock.IsEnabled);
        }
        public void Error_ShouldBeLogged_WhenConnectedClientDidNotEchoed()
        {
            _listenerMock.SimulateClientConnection();
            _receiverMock.SimulateEchoTimeout();
            Assert.AreEqual("Client did not reply", _loggerMock.RecentErrorMessage);
        }
    }
