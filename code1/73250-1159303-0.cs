    class MyClass
    {
        private delegate void SomeFunctionDelegate(int param1, bool param2);
        private SomeFunctionDelegate sfd;
        public MyClass()
        {
            sfd = new SomeFunctionDelegate(this.SomeFunction);
        }
        private void SomeFunction(int param1, bool param2)
        {
            // Do stuff
            // Notify user
        }
        public void GetData()
        {
            // Do stuff
            sfd.BeginInvoke(34, true, null, null);
        }
    }
