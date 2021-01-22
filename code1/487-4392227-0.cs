    public class APIClass
    {
        private static const string DllName = "external.dll";
        [DllImport(DllName)]
        public static extern unsafe uint external_setSomething(int x, uint y);
        [DllImport(DllName)]
        public static extern unsafe uint external_getSomething(int x, uint* y);
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
        public valueEnum Something
        {
            get
            {
                valueEnum y;
                APIClass.external_getSomething(Identifier, y);
                return y;
            }
            set
            {
                APIClass.external_setSomething(Identifier, value);
            }
        }
        new private uint external_setSomething(int x, float y) { }
        new private unsafe uint external_getSomething(int x, float* y) { }
    }
