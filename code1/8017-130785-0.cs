        public interface IConfigManager
        {
            string FooSetting { get; set; }
        }
    
        public class Class2Test
        {
            private IConfigManager _config;
            public Class2Test(IConfigManager configManager)
            {
                _config = configManager;   
            }
    
            public void methodToTest()
            {
                //do something important with ConfigManager.FooSetting
                var important = _config.FooSetting;
                return important;
            }
        }
    
        [TestClass]
        public class When_doing_something_important
        {
            [TestMethod]
            public void Should_use_configuration_values()
            {
                IConfigManager fake = new FakeConfigurationManager();
                //setup state
                fake.FooSetting = "foo";
                var sut = new Class2Test(fake);
                Assert.AreEqual("foo", sut.methodToTest());
            }
        }
