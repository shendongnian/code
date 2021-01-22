     public class TestClass
     {
        private string _myField;
        public TestClass(string myField)
        {
          _myField = myField;
        }
        public string MyField {get { return _myField;} set {_myField = value}}
     }
