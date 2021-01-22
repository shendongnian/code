    [TestFixture]
    public class SampleProviderTests {
        public interface ISampleProvider<TEntity> {
            TEntity Entity { get; }
        }
        public class SampleProvider<TEntity> : ISampleProvider<TEntity> {
            public SampleProvider(TEntity entity) {
                Entity = entity;
            }
            public TEntity Entity { get; private set; }
        }
        public class Person {}
        [Test]
        public void test() {
            var container = new WindsorContainer();
            container.AddComponent("smaple_provider", typeof(ISampleProvider<Person>), typeof(SampleProvider<Person>));
            var arguments = new Hashtable { { "entity", new Person() } };
            var sampleProvider = container.Resolve<ISampleProvider<Person>>(arguments);            
        }
    }
