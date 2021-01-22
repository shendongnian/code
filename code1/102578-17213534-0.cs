        public static int GetNativeThreadId(Thread thread)
        {
            var f = typeof(Thread).GetField("DONT_USE_InternalThread",
                BindingFlags.GetField | BindingFlags.NonPublic | BindingFlags.Instance);
            var pInternalThread = (IntPtr)f.GetValue(thread);
            var nativeId = Marshal.ReadInt32(pInternalThread, 548); // found by analyzing the memory
            return nativeId;
        }
