    using Microsoft.Build.Framework;
    using NUnit.Framework;
    using Rhino.Mocks;
    
    namespace NameSpace
    {
        [TestFixture]
        public class Tests
        {
            [Test]
            public void Test()
            {
                MockRepository mock = new MockRepository();
                IBuildEngine engine = mock.Stub<IBuildEngine>();
    
                var appSettings = new AppSettings();
                appSettings.BuildEngine = engine;
                appSettings.Execute();
            }
        }
    }
