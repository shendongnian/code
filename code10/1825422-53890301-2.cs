        /// <summary>
        /// Maps the supplied byte array onto a structure of the specified type.
        /// </summary>
        public static T ToStructure<T>(byte[] data)
        {
            unsafe
            {
                fixed (byte* p = &data[0])
                {
                    return (T)Marshal.PtrToStructure(new IntPtr(p), typeof(T));
                }
            };
        }
