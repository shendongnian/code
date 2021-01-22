    namespace SDK_DLL_NS
       {
          internal class SDK_DLL
             {
                [DllImport("../../../SDK/SDK.dll")]
                public static extern unsafe int SDK_AMethod(int devHandle, IntPtr buf, int length);
                public const int MAX_LEN = 12345;  
    .....
        }
    }
