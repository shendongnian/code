    namespace CounterTest {
        public class Counter : ModelBase {
            private int _cval;
    
            public int Cval { // This is the value to increment.
                get { return _cval; }
                set {
                    if (_cval != value) {
                        _cval = value;
                        RaisePropertyChanged(nameof(Cval));
                    }
                }
            }
    
            public Counter() { Cval = 0; }
    
            public void Increment() { Cval++; }
            public bool CanIncrement() { return true; } // Only needed to conform to ICommand interface. // Mikant: not really needed. not here
        }
    }
