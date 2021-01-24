    [DllImport("msvcrt.dll", CallingConvention = CallingConvention.Cdecl)]
    static extern int memcmp(IntPtr b1, IntPtr b2, IntPtr count);
    public static unsafe bool UnsafeCompare2(int[] ary1, int[] ary2)
    {
       fixed (int* pAry1 = ary1, pAry2 = ary2)
       {
          return memcmp((IntPtr)pAry1, (IntPtr)pAry2, (IntPtr)(ary2.Length * sizeof(int))) == 0;
       }
    }
