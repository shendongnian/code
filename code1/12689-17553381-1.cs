    class Foo
    {
        public Foo()
        {
            GoHelper();
        }
        public void GoHelper()
        {
            for (float i = float.MinValue; i < float.MaxValue; i+= 0.000000000000001f)
            {
                Go();
            }
        }
        public void Go()
        {
            byte[] b = new byte[1]; // Will get cleaned by GC
        }   // right now
    }
