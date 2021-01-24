        private AutoResetEvent _are;
        [TestMethod]
        public void DllLoadingTest() {
            Init();
            LoadCores();
            TestAsync(method,
                new[] { new Uri(lnk) },
                "./part{0}.rar");
        }
        void TestAsync(string method, IEnumerable<Uri> links, string pathTemplate) {
            object instance = _dlls[method];
            MethodInfo mInfo = instance.GetType().GetMethod("Download");
            mInfo.Invoke(instance, new object[] { links, pathTemplate });
            _are.WaitOne();
        }
[...]
        public void OnDownloadFinished(object sender, EventArgs args) {
            Debug.WriteLine("Download finished.");
            _are.Set();
        }
