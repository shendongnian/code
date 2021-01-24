    [StructLayout(LayoutKind.Sequential)]
    public struct Unmanaged2d
    {
        public IntPtr arr;
        public int n;
        public int m;
        public static MyPodStruct[,] Fill2dResult()
        {
            Unmanaged2d unsafeRes = new Unmanaged2d();
            //unsafe_Init2d(ref unsafeRes, n, m); // I have n, m from elsewhere
            //unsafe_Fill2dResult(ref unsafeRes);
            MyPodStruct[,] res = new MyPodStruct[unsafeRes.n, unsafeRes.m];
            for (int i = 0; i < unsafeRes.n; i++)
            {
                IntPtr row = Marshal.ReadIntPtr(unsafeRes.arr, i * IntPtr.Size);
                for (int j = 0, offset = 0; j < unsafeRes.m; j++)
                {
                    // Automatic marshaling of MyPodStruct
                    // res[i, j] = Marshal.PtrToStructure<MyPodStruct>(row + j * (sizeof(double) + sizeof(double)));
                    // Manual marshaling
                    // a
                    long temp1 = Marshal.ReadInt64(row, offset);
                    double dbl1 = BitConverter.Int64BitsToDouble(temp1);
                    offset += sizeof(double);
                    // b
                    long temp2 = Marshal.ReadInt64(row, offset);
                    double dbl2 = BitConverter.Int64BitsToDouble(temp2);
                    offset += sizeof(double);
                    res[i, j] = new MyPodStruct { a = dbl1, b = dbl2 };
                }
            }
            //unsafe_Free2d(ref unsafeRes);
            return res;
        }
    }
