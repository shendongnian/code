    public class ValueApiTest
    {
        private ValuesController _objValuesController;
        private string[] _expected = new string[] {"Value1", "Value2"};
        public ValueApiTest() {
            _expected = Mock<IValueLogic> mockValueLogic = new Mock<IValueLogic>();          
            mockValueLogic.Setup(x => x.GetAll()).Returns(expected);
            _objValuesController = new ValuesController(mockValueLogic.Object);
        }
       [Fact]
        public void GetAll_Success() {
            IEnumerable<string> actual = _objValuesController.Get().Value;
            Assert.Equal<IEnumerable<string>>(expected, actual);
        }
    }
