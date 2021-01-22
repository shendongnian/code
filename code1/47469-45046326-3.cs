	using System.Collections.Specialized;
	using System.Web;
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	namespace UtilTests
	{
		[TestClass]
		public class IP
		{
			[TestMethod]
			public void TestForwardedObfuscated()
			{
				var request = new HttpRequestMock("for=\"_gazonk\"");
				Assert.AreEqual("_gazonk", Util.IP.GetIPAddress(request));
			}
			[TestMethod]
			public void TestForwardedIPv6()
			{
				var request = new HttpRequestMock("For=\"[2001:db8:cafe::17]:4711\"");
				Assert.AreEqual("2001:db8:cafe::17", Util.IP.GetIPAddress(request));
			}
			[TestMethod]
			public void TestForwardedIPv4()
			{
				var request = new HttpRequestMock("for=192.0.2.60;proto=http;by=203.0.113.43");
				Assert.AreEqual("192.0.2.60", Util.IP.GetIPAddress(request));
			}
			[TestMethod]
			public void TestForwardedIPv4WithPort()
			{
				var request = new HttpRequestMock("for=192.0.2.60:443;proto=http;by=203.0.113.43");
				Assert.AreEqual("192.0.2.60", Util.IP.GetIPAddress(request));
			}
			[TestMethod]
			public void TestForwardedMultiple()
			{
				var request = new HttpRequestMock("for=192.0.2.43, for=198.51.100.17");
				Assert.AreEqual("192.0.2.43", Util.IP.GetIPAddress(request));
			}
		}
		public class HttpRequestMock : HttpRequestBase
		{
			private NameValueCollection headers = new NameValueCollection();
			public HttpRequestMock(string forwarded)
			{
				headers["Forwarded"] = forwarded;
			}
			public override NameValueCollection Headers
			{
				get { return this.headers; }
			}
		}
	}
