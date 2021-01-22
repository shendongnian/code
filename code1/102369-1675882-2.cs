    public class MyClass
    {
        private readonly IRuntimeInfo _runtimeInfo = null;
        public MyClass (IRuntimeInfo runtimeInfo)
        {
            _runtimeInfo = runtimeInfo;
        }
        public void SomeMethod ()
        {
            if (_runtimeInfo.IsSilverlight)
            {
                // do your thang
            }
            else
            {
                // do some other thang
            }
        }
    }
