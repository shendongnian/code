    [TestClass]
    public class IPAddressExtensionsTests
    {
        [TestMethod]
        public void SimpleIp1()
        {
            var ip = IPAddress.Parse("0.0.0.15");
            uint expected = GetExpected(0, 0, 0, 15);
            Assert.AreEqual(expected, ip.ToUint());
        }
        [TestMethod]
        public void SimpleIp2()
        {
            var ip = IPAddress.Parse("0.0.1.15");
            uint expected = GetExpected(0, 0, 1, 15);
            Assert.AreEqual(expected, ip.ToUint());
        }
        [TestMethod]
        public void SimpleIpSix1()
        {
            var ip = IPAddress.Parse("0.0.0.15").MapToIPv6();
            uint expected = GetExpected(0, 0, 0, 15);
            Assert.AreEqual(expected, ip.ToUint());
        }
        [TestMethod]
        public void SimpleIpSix2()
        {
            var ip = IPAddress.Parse("0.0.1.15").MapToIPv6();
            uint expected = GetExpected(0, 0, 1, 15);
            Assert.AreEqual(expected, ip.ToUint());
        }
        [TestMethod]
        public void HighBits()
        {
            var ip = IPAddress.Parse("200.12.1.15").MapToIPv6();
            uint expected = GetExpected(200, 12, 1, 15);
            Assert.AreEqual(expected, ip.ToUint());
        }
        uint GetExpected(uint a, uint b, uint c, uint d)
        {
            return
                (a * 256u * 256u * 256u) +
                (b * 256u * 256u) +
                (c * 256u) +
                (d);
        }
    }
