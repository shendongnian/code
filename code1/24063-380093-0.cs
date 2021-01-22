        public static T Get<T>(byte[] msg, int offset)
        {
            
            T[] t = new T[] { default(T) };
            int len = Marshal.SizeOf(typeof(T));
            GCHandle th = GCHandle.Alloc(t, GCHandleType.Pinned);
            GCHandle mh = GCHandle.Alloc(msg, GCHandleType.Pinned);
            try
            {
                unsafe
                {
                    byte* pb = (byte*)mh.AddrOfPinnedObject();
                    byte* srcptr = pb + offset;
                    byte* dest = ((byte*)th.AddrOfPinnedObject());
                    for (int i = 0; i < len; i++)
                    {
                        dest[i] = srcptr[i];
                    }
                }
            }
            finally
            {
                mh.Free();
                th.Free();
            }
            
            return t[0];
        }
        public static string GetString(byte[] msg, int offset, int length)
        {
            StringBuilder retVal = new StringBuilder(length);
            unsafe
            {
                fixed (byte* pb = msg)
                {
                    byte* pc = (byte*)(pb + offset);
                    for (int x = 0; x < length; x++)
                    {
                        if (pc[x] == 0) break;
                        retVal.Append((char)pc[x]);
                    }
                }
            }
            return retVal.ToString(0, retVal.Length);
        }
