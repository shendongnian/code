    public sealed class Native
    {
        public static Int32 GetVerticalScrollbarWidth()
        {
            return GetSystemMetrics(SM_CXVSCROLL);
        }
        public Int32 GetHorizontalScrollbarHeight()
        {
            return GetSystemMetrics(SM_CYHSCROLL);
        }
        [DllImport("coredll.dll", SetLastError = true)]
        public static extern Int32 GetSystemMetrics(Int32 index);
        
        public const Int32
            SM_CXVSCROLL = 2,
            SM_CYHSCROLL = 3;
    }
