    public static class Direct2D1Util {
        public const string IID_ID2D1Factory =
            "06152247-6f50-465a-9245-118bfd3b6007";
        [DllImport("d2d1.dll", PreserveSig = false)]
        [return: MarshalAs(UnmanagedType.Interface)]
        private static extern object D2D1CreateFactory(D2D1_FACTORY_TYPE factoryType,
            [MarshalAs(UnmanagedType.LPStruct)] Guid riid,
            D2D1_FACTORY_OPTIONS pFactoryOptions);
        public static ID2D1Factory CreateFactory() {
            D2D1_FACTORY_OPTIONS opts = new D2D1_FACTORY_OPTIONS();
            object factory = D2D1CreateFactory(
                D2D1_FACTORY_TYPE.D2D1_FACTORY_TYPE_SINGLE_THREADED,
                new Guid(IID_ID2D1Factory), opts);
            return (ID2D1Factory)factory;
        }
    }
