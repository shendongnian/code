       [Fact]
        public void SentinelGetMasterAddressByNameTest()
        {
            var endpoint = Server.SentinelGetMasterAddressByName(ServiceName);
            Assert.NotNull(endpoint);
            var ipEndPoint = endpoint as IPEndPoint;
            Assert.NotNull(ipEndPoint);
            Log("{0}:{1}", ipEndPoint.Address, ipEndPoint.Port);
        }
