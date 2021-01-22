    class FooBar
    {
        //other code goes here
        public FooBar()
        {
            m_wrmversion = (string)regkey.GetValue(SpoRegistry.regValue_CurrentVersion);
        }
    }
