        //The Class to Test
        public class ObjectY
        {
            public string DoThis(IObjectX objectX)
            {
                return objectX.id + objectX.name;
            }
        }
        [Test]
        //The test
        public void CreaeteTestData()
        {
            //Almost prosa style creation of test data 
            var testData = new ObjectXBuilder().WithId(123).WithName("ABC").Build();
            
            Assert.That(new ObjectY().DoThis(testData), Is.EqualTo("123ABC"));
        }
        //The Builder class - Provides easy creation testdata.
        internal class ObjectXBuilder
        {
            private MockRepository _mockRepository;
            private IObjectX _objectX;
            public ObjectXBuilder()
            {
                _mockRepository = new MockRepository();
                _objectX = _mockRepository.Stub<IObjectX>();
            }
            public ObjectXBuilder WithName(string name)
            {
                _objectX.name = name;
                return this;
            }
            public ObjectXBuilder WithId(long id)
            {
                _objectX.id = id;
                return this; 
            }
            public IObjectX Build()
            {
                _mockRepository.ReplayAll();
                return _objectX;
            }
        }
