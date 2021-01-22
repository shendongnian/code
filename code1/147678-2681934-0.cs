        [ComVisible(true)]
        [StructLayout(LayoutKind.Sequential)]
        public class MY_CLASS
        {
            [MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.I4)]
            public Int32[] width;
            [MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.I4)]
            public Int32[] height;
        };
        [DllImport("mydll.dll")]
        public static extern Int32 GetTypes(
            [In, Out] MY_CLASS myClass
            );
