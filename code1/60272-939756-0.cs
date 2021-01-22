    class A {
        public string strField = 'string';
        public int intField = 10;
    }
    class AWrapper {
        private A _aObj;
        public AWrapper(A aobj) {
          _aObj = A;
        }
        public string strField {
             get {
                return _aObj.strField;
             }
        }
        public int intField {
             get {
                return _aObj.intField;
             }
        }
    }
