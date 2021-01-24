    [StructLayout(LayoutKind.Sequential, Size = 16)]
    public struct MyPodStruct // Plain Old Data
    {
        public double a;
        public double b;
    };
    [StructLayout(LayoutKind.Sequential)]
    public struct Unmanaged2d
    {
        public IntPtr arr;
        public int n;
        public int m;
        public unsafe ref MyPodStruct this[int x, int y]
        {
            get
            {
                if (x < 0 || x >= n)
                {
                    throw new ArgumentOutOfRangeException(nameof(x));
                }
                if (y < 0 || y >= m)
                {
                    throw new ArgumentOutOfRangeException(nameof(y));
                }
                IntPtr ptr = Marshal.ReadIntPtr(arr, x * sizeof(IntPtr));
                IntPtr ptr2 = ptr + y * 16; // 16 == sizeof(MyPodStruct)
                return ref Unsafe.AsRef<MyPodStruct>(ptr2.ToPointer());
            }
        }
    }
    unsafe_Init2d(ref unsafeRes, n, m);
    // We increase all the values of a and b, just to show that we can!
    for (int i = 0; i < u.n; i++)
    {
        for (int j = 0; j < u.m; j++)
        {
            u[i, j].a += 10;
            u[i, j].b++;
        }
    }
    // We print them
    for (int i = 0; i < u.n; i++)
    {
        Console.WriteLine(string.Join(";", Enumerable.Range(0, u.m).Select(x => string.Format($"({u[i, x].a},{u[i, x].b})"))));
    }
