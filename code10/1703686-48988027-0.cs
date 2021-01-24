    [StructLayout(LayoutKind.Sequential)]
    public struct Vector3
    {
        public float x;
        public float y;
        public float z;
    };
    [StructLayout(LayoutKind.Sequential)]
    public struct PointState
    {
        public Vector3 position_;
        private byte _reformation;
        public bool reformation { get { return _reformation != 0; } }
    };
    [DllImport("path", CallingConvention = CallingConvention.Cdecl)]
    private static extern PointState CheckStruct();
