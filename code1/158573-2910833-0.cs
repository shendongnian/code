    public class Test
    {
        private string[] _a;
        private int[] _b;
    
        public string[] A
        {
            get { return this._a; }
            private set { this._a = value; }
        }
    
        public int[] B
        {
            get { return this._b; }
            private set { this._b = value; }
        }
    
        public Test()
        {
            // todo add ctor logic here
        }
    }
    
    // now you can do:
    
    Test t = new Test();
    
    t.A[1] = "blah"; // assuming that index of the array is defined.
