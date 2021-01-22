    namespace {
        public class Base {
            private int _baseProperty = 0;
            
            public virtual int BaseProperty {
                get {
                    return _baseProperty;
                }
            }
        }
        public class Test : Base {
            private int _testBaseProperty = 5;
            
            public new int BaseProperty {
                get {
                    return _testBaseProperty;
                }
                set {
                    _testBaseProperty = value;
                }
            }
        }
    }
 
        
