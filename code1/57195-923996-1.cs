    namespace WindsorTests {
        public interface IService {}    
        public class Service1 : IService {}    
        public class Service2 : IService {}    
        public class Consumer {
            private readonly IDictionary<string, IService> services;    
            public IDictionary<string, IService> Services {
                get { return services; }
            }    
            public Consumer(IDictionary<string, IService> services) {
                this.services = services;
            }
        }    
    
        [TestFixture]
        public class WindsorTests {    
            [Test]
            public void DictTest() {
                var container = new WindsorContainer(new XmlInterpreter(new StaticContentResource(@"<castle>
    <components>
        <component id=""service1"" service=""WindsorTests.IService, MyAssembly"" type=""WindsorTests.Service1, MyAssembly""/>
        <component id=""service2"" service=""WindsorTests.IService, MyAssembly"" type=""WindsorTests.Service2, MyAssembly""/>
        <component id=""consumer"" type=""WindsorTests.Consumer, MyAssembly"">
            <parameters>
                <services>
                    <dictionary>
                        <entry key=""one"">${service1}</entry>
                        <entry key=""two"">${service2}</entry>
                    </dictionary>
                </services>
            </parameters>
        </component>
    </components>
    </castle>")));
                var consumer = container.Resolve<Consumer>();
                Assert.AreEqual(2, consumer.Services.Count);
                Assert.IsInstanceOfType(typeof(Service1), consumer.Services["one"]);
                Assert.IsInstanceOfType(typeof(Service2), consumer.Services["two"]);
            }
        }
    }
