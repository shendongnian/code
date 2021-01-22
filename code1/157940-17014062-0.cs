        [Test]
        public void TestTemporaryFile_without_Dispose()
        {
            const string DOMAIN_NAME = "testDomain";
            const string FILENAME_KEY = "fileName";
            string testRoot = Directory.GetCurrentDirectory();
            AppDomainSetup info = new AppDomainSetup
                                      {
                                          ApplicationBase = testRoot
            };
            AppDomain testDomain = AppDomain.CreateDomain(DOMAIN_NAME, null, info);
            testDomain.DoCallBack(delegate
            {
                TemporaryFile temporaryFile = new TemporaryFile();
                Assert.IsTrue(File.Exists(temporaryFile.FileName));
                AppDomain.CurrentDomain.SetData(FILENAME_KEY, temporaryFile.FileName);
            });
            string createdTemporaryFileName = (string)testDomain.GetData(FILENAME_KEY);
            Assert.IsTrue(File.Exists(createdTemporaryFileName));
            AppDomain.Unload(testDomain);
            Assert.IsFalse(File.Exists(createdTemporaryFileName));
        }
