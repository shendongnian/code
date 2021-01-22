    public sealed class AppVPEntry : IDisposable {
        [StructLayout(LayoutKind.Sequential, Size = 264)]
        internal struct _AppVPEntry {
            [MarshalAs(UnmanagedType.I4)]
            public Int32 Num;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
            public Byte[] CompName;
            [MarshalAs(UnmanagedType.I4)]
            public Int32 VPBeginAddress;
        }
        private readonly IntPtr unmanaged;
        private readonly _AppVPEntry managed = new _AppVPEntry();
        public AppVPEntry(Int32 num, String path, Int32 beginAddress) {
            this.managed.Num = num;
            this.managed.CompName = new byte[256];
            Buffer.BlockCopy(Encoding.ASCII.GetBytes(path), 0, this.managed.CompName, 0, Math.Min(path.Length, 256));
            this.managed.VPBeginAddress = beginAddress;
            this.unmanaged = Marshal.AllocHGlobal(264);
            Marshal.StructureToPtr(this.managed, this.unmanaged, false);
        }
        public void Dispose() {
            Marshal.FreeHGlobal(this.unmanaged);
        }
    }
