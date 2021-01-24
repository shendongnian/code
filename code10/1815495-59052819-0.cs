       public Sentinel(ITestOutputHelper output) : base(output)
        {
            ConnectionLog = new StringWriter();
            Skip.IfNoConfig(nameof(TestConfig.Config.SentinelServer), TestConfig.Current.SentinelServer);
            Skip.IfNoConfig(nameof(TestConfig.Config.SentinelSeviceName), TestConfig.Current.SentinelSeviceName);
            var options = new ConfigurationOptions()
            {
                CommandMap = CommandMap.Sentinel,
                EndPoints = { { TestConfig.Current.SentinelServer, TestConfig.Current.SentinelPort } },
                AllowAdmin = true,
                TieBreaker = "",
                ServiceName = TestConfig.Current.SentinelSeviceName,
                SyncTimeout = 5000
            };
            Conn = ConnectionMultiplexer.Connect(options, ConnectionLog);
            Thread.Sleep(3000);
            Assert.True(Conn.IsConnected);
            Server = Conn.GetServer(TestConfig.Current.SentinelServer, TestConfig.Current.SentinelPort);
        }
