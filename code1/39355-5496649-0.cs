        public byte[] ToByteArray(object o)
        {
            int size = Marshal.SizeOf(o);
            byte[] buffer = new byte[size];
            IntPtr p = Marshal.AllocHGlobal(size);
            try
            {
                Marshal.StructureToPtr(o, p, false);
                Marshal.Copy(p, buffer, 0, size);
            }
            finally
            {
                Marshal.FreeHGlobal(p);
            }
            return buffer;
        }
