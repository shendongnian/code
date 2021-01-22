    [TestFixture]
    public class WindsorTests {
        public interface IDataService {}
    
        public class DataService: IDataService {}
    
        public interface IDataFactory {
            IDataService Service { get; }
        }
    
        public class DataFactory: IDataFactory {
            public IDataService Service {
                get { return new DataService(); }
            }
        }
    
        [Test]
        public void FactoryTest() {
            var container = new WindsorContainer();
            container.AddFacility<FactorySupportFacility>();
            container.AddComponent<IDataFactory, DataFactory>();
            container.Register(Component.For<IDataService>().UsingFactory((IDataFactory f) => f.Service));
            var service = container.Resolve<IDataService>();
            Assert.IsInstanceOfType(typeof(DataService), service);
        }
    }
