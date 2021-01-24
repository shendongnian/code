    public class MyClass
    {
        private int _myProperty;
        public int MyProperty
        {
            get
            {
                return _myProperty;
            }
            set
            {
                // using System.Diagnostics
                StackTrace st = new StackTrace(); // get the current stack trace
                StackFrame sf = st.GetFrame(st.FrameCount - 1); // get the last frame
                Debug.WriteLine($"My Property Set by {sf.GetMethod().Name}.  New value: {value}");
    
                _myProperty = value;
            }
        }
    }
