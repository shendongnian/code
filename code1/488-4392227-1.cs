    public class APIClass
    {
        private static const string DllName = "external.dll";
        [DllImport(DllName)]
        public extern unsafe uint external_setSomething(int x, uint y);
        [DllImport(DllName)]
        public extern unsafe uint external_getSomething(int x, uint* y);
        public enum valueEnum
        {
            On = 0x01000000;
            Off = 0x00000000;
            OnWithOptions = 0x01010000;
            OffWithOptions = 0x00010000;
        }
    }
    public class APIUsageClass : APIClass
    {
        public int Identifier;
        private APIClass m_internalInstance = new APIClass();
        public valueEnum Something
        {
            get
            {
                unsafe
                {
                    valueEnum y;
                    fixed (valueEnum* yPtr = &y)
                    {
                        m_internalInstance.external_getSomething(Identifier, yPtr);
                    }
                    return y;
                }
            }
            set
            {
                m_internalInstance.external_setSomething(Identifier, value);
            }
        }
        new private uint external_setSomething(int x, float y) { }
        new private unsafe uint external_getSomething(int x, float* y) { }
    }
