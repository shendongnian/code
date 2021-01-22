    public class MyClass
    {
        // initialized to null
        private string _myString = null;
        // _myString is initialized, but this throws null reference
        public int StringLength { get { return _myString.Length(); } }
    }
