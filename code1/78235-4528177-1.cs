    [DllImport("somedll.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern Int16 rsttwi_temp(ref Phenomenon value);
    [StructLayout(LayoutKind.Sequential)]
            public struct Phenomenon
            {
                [MarshalAs(UnmanagedType.R8)]
                public double Jd;
                [MarshalAs(UnmanagedType.R8)]
                public double Loc_jd;
                [MarshalAs(UnmanagedType.R8)]
                public double Angle;
                [MarshalAs(UnmanagedType.I2)]
                public Int16 Warning;
            }
    
