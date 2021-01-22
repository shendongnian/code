    class MyClass {
        private string aString;
        
        public string AString {
            get { return aString; }
            set {aString = value; }
        }
    }
    MyClass test = new MyClass {
        AString = "test"
    };
