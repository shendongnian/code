    internal class Native
    {
        [DllImport("string_return")]
        internal static extern ThemeSongHandle theme_song_generate(byte length);
        [DllImport("string_return")]
        internal static extern void theme_song_free(IntPtr song);
    }
    
    internal class ThemeSongHandle : SafeHandle
    {
        public ThemeSongHandle() : base(IntPtr.Zero, true) {}
    
        public override bool IsInvalid
        {
            get { return false; }
        }
    
        public string AsString()
        {
            int len = 0;
            while (Marshal.ReadByte(handle, len) != 0) { ++len; }
            byte[] buffer = new byte[len];
            Marshal.Copy(handle, buffer, 0, buffer.Length);
            return Encoding.UTF8.GetString(buffer);
        }
    
        protected override bool ReleaseHandle()
        {
            Native.theme_song_free(handle);
            return true;
        }
    }
