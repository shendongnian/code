    public class A {
        private static A _instance;
        private A() { }
        public static A Instance {
            get {
                try {
                    return _instance.Self();
                } catch (NullReferenceException) {
                    lock (typeof(A)) {
                        if (_instance == null)
                            _instance = new A();
                    }
                }
                return _instance.Self();
            }
        }
        private A Self() { return this; }
    }
