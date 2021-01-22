    class Program
    {
        [DllImport(@"TestLib.dll")]
        private static extern void InitializeMatrix(IntPtr ptr, int rows, int cols);
    
        static void Main(string[] args)
        {
            const int rowsCount = 3;
            const int colsCount = 4;
    
            // Allocate memory for the matrix: (rowsCount * sizeof(IntPtr)) * (colsCount * sizeof(int))
            IntPtr ptr = AllocateMatrix(rowsCount, colsCount);
            try
            {
                // Call unmanaged routine to fill the allocated memory with data
                InitializeMatrix(ptr, rowsCount, colsCount);
    
                // Marshal back data
                int[][] matrix = GetMatrixFromPointer(ptr, rowsCount, colsCount);
                // Pretty-print the matrix
                for (int i = 0; i < rowsCount; i++)
                {
                    for (int j = 0; j < colsCount; j++)
                    {
                        Console.Write("{0} ", matrix[i][j]);
                    }
                    Console.WriteLine();
                }
            }
            finally
            {
                // Release allocated memory
                FreeMatrix(ptr, rowsCount, colsCount);
            }
        }
    
        private static IntPtr AllocateMatrix(int rowsCount, int colsCount)
        {
            IntPtr ptr = Marshal.AllocHGlobal(rowsCount * Marshal.SizeOf(typeof(IntPtr)));
            IntPtr[] rows = new IntPtr[rowsCount];
            for (int i = 0; i < rowsCount; i++)
            {
                int[] cols = new int[colsCount];
                rows[i] = Marshal.AllocHGlobal(colsCount * Marshal.SizeOf(typeof(int)));
                Marshal.Copy(cols, 0, rows[i], colsCount);
            }
            Marshal.Copy(rows, 0, ptr, rows.Length);
            return ptr;
        }
    
        private static int[][] GetMatrixFromPointer(IntPtr ptr, int rowsCount, int colsCount)
        {
            int[][] result = new int[rowsCount][];
            IntPtr[] rows = new IntPtr[rowsCount];
            Marshal.Copy(ptr, rows, 0, rowsCount);
            for (int i = 0; i < rowsCount; i++)
            {
                int[] cols = new int[colsCount];
                Marshal.Copy(rows[i], cols, 0, colsCount);
                result[i] = cols;
            }
            return result;
        }
    
        private static void FreeMatrix(IntPtr ptr, int rowsCount, int colsCount)
        {
            IntPtr[] rows = new IntPtr[rowsCount];
            Marshal.Copy(ptr, rows, 0, rowsCount);
            for (int i = 0; i < rowsCount; i++)
            {
                Marshal.FreeHGlobal(rows[i]);
            }
            Marshal.FreeHGlobal(ptr);
        }
    }
