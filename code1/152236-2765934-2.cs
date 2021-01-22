    using System.Net;
    using NUnit.Framework;
    
    namespace Salient.Excerpts
    {
        [TestFixture]
        public class WebHostServerFixture : WebHostServer
        {
            [TestFixtureSetUp]
            public void TestFixtureSetUp()
            {
                // debug/bin/testproject/solution/siteundertest - make sense?
                StartServer(@"..\..\..\..\TestSite");
    
                // is the equivalent of
                // StartServer(@"..\..\..\..\TestSite",
                // GetAvailablePort(8000, 10000, IPAddress.Loopback, true), "/", "localhost");
            }
            [TestFixtureTearDown]
            public void TestFixtureTearDown()
            {
                StopServer();
            }
    
            [Test]
            public void Test()
            {
                // while a reference to the web app under test is not necessary,
                // if you do add a reference to this test project you may F5 debug your tests.
                // if you debug this test you will break in Default.aspx.cs
                string html = new WebClient().DownloadString(NormalizeUri("Default.aspx"));
            }
        }
    }
