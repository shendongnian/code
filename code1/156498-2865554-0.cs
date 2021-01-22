        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct FormulaSyntax {
            public short StructSize;
            [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.I4,
                                                SizeConst = 2)]
            public short[] formulaSyntax;
        }
