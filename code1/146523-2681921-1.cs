    class MyCaptureClass
    {
        private readonly int i, j;
        int? result;
        // only available after execution
        public int Result { get { return result.Value; } }
        public MyCaptureClass(int i, int j)
        {
            this.i = i;
            this.j = j;
        }
        public void Invoke()
        { // will also need a target object if Fun1 isn't static
            result = Fun1(i, j);
        }
    }
    ...
    MyCaptureClass capture = new MyCaptureClass(5, 12);
    Thread FirstThread = new Thread(capture.Invoke);
    // then in the future, access capture.Result
