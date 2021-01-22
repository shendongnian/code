    class one
    {
        internal static void MethodA()
        {
            //Do Something here.  SHOULD be calling B.
        }
        internal virtual void MethodB()
        {
             //MUST be called by MethodA.
        }
    }
    class three : one
    {
        public bool wasCalled;
        override void MethodB()
        {
             wasCalled=true;
        }
    }
    class two
    {
        internal void MethodA()
        {
            three.ClassA();
            if (three.wasCalled)
            {
            }
        }
    } 
