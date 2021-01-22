    [StructLayout(LayoutKind.Sequential)]
    struct Matrix
    {
        public int RowsCount;
        public int ColsCount;
        public IntPtr Data;
    }
    
    class Program
    {
        [DllImport("TestLib.dll")]
        private static extern void InitializeMatrix(IntPtr ptr, int count);
    
        static void Main(string[] args)
        {
            const int count = 3;
    
            // Allocate memory
            IntPtr ptr = Marshal.AllocHGlobal(count * Marshal.SizeOf(typeof(IntPtr)));
            IntPtr[] matrices = new IntPtr[count];
            for (int i = 0; i < count; i++)
            {
                Matrix matrix = new Matrix();
                // Give some size to the matrix
                matrix.RowsCount = 4;
                matrix.ColsCount = 3;
                int size = matrix.RowsCount * matrix.ColsCount;
                int[] data = new int[size];
                matrix.Data = Marshal.AllocHGlobal(size * Marshal.SizeOf(typeof(int)));
                Marshal.Copy(data, 0, matrix.Data, size);
    
                matrices[i] = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(Matrix)));
                Marshal.StructureToPtr(matrix, matrices[i], true);
            }
            Marshal.Copy(matrices, 0, ptr, count);
    
    
            // Call unmanaged routine
            InitializeMatrix(ptr, count);
    
            Console.WriteLine("<managed>");
            // Read data back
            Marshal.Copy(ptr, matrices, 0, count);
            for (int i = 0; i < count; i++)
            {
                Matrix m = (Matrix)Marshal.PtrToStructure(matrices[i], typeof(Matrix));
                int size = m.RowsCount * m.ColsCount;
                int[] data = new int[size];
                Marshal.Copy(m.Data, data, 0, size);
    
                // Pretty-print the matrix
                Console.WriteLine("rows: {0} cols: {1}", m.RowsCount, m.ColsCount);
                for (int j = 0; j < m.RowsCount; j++)
                {
                    for (int k = 0; k < m.ColsCount; k++)
                    {
                        Console.Write("{0} ", data[k * m.RowsCount + j]);
                    }
                    Console.WriteLine();
                }
            }
            Console.WriteLine("</managed>");
    
    
            // Clean the whole mess (try...finally block omitted for clarity)
            for (int i = 0; i < count; i++)
            {
                Matrix m = (Matrix)Marshal.PtrToStructure(matrices[i], typeof(Matrix));
                Marshal.FreeHGlobal(m.Data);
                Marshal.FreeHGlobal(matrices[i]);
            }
            Marshal.FreeHGlobal(ptr);
        }
    }
