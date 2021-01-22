     public class GlobalTest : Global
        {
            private HttpRequestMessage FakeRequest;
            
            DateTime? effectiveDate = DateTime.Now.AddYears(-4);
            private string policyNumber = "1234567890";
    
            [TestMethod]
            public void ApplicationStart()
            {
                var sender = new object();
                var e = new EventArgs();
                try
                {
                    Application_Start(sender, e); // this will error b/c not fully loaded yet.
                }
                catch (InvalidOperationException)
                {
                    Thread.Sleep(2000); // give the app time to launch
    
                    Application_Start(sender, e);
                }
                Assert.IsTrue(true);
            }
        }
