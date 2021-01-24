    BrowserWindow window;
        [TestMethod]
        public void Method1()
        {
            window = BrowserWindow.Launch(new Uri("http://www.bing.com"));
            window.CloseOnPlaybackCleanup = false;
        }
        [TestMethod]
        public void Method2()
        {
            window = BrowserWindow.Locate("Bing");
            window.CloseOnPlaybackCleanup = false;
        }
        [TestMethod]
        public void Method3()
        {
            window = BrowserWindow.Locate("Bing");
        }
    
