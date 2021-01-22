    private string GetPathFromPIDL(byte[] byteCode)
        {
            //MAX_PATH = 260
            StringBuilder builder = new StringBuilder(260);
            IntPtr ptr = IntPtr.Zero;
            GCHandle h0 = GCHandle.Alloc(byteCode, GCHandleType.Pinned);
            try
            {
                ptr = h0.AddrOfPinnedObject();
            }
            finally
            {
                h0.Free();
            }
            SHGetPathFromIDListW(ptr, builder);
            return builder.ToString();
        }
