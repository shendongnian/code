    class BlockData
    {
        public int[,] data;
        internal void reindex(int n, int x, int y, out int xx, out int yy)
        {
            const int blockSize = 4;
            int width = data.GetLength(0);
            int columns = width / blockSize;
            int row = n / columns;
            int col = n % columns;
            xx = col * blockSize + x;
            yy = row * blockSize + y;
        }
        public int this[int n, int x, int y]
        {
            get
            {
                int xx, yy;
                reindex(n, x, y, out xx, out yy);
                return data[xx, yy];
            }
            set
            {
                int xx, yy;
                reindex(n, x, y, out xx, out yy);
                data[xx, yy] = value;
            }
        }
        public int this[int xx, int yy]
        {
            get
            {
                return data[xx, yy];
            }
            set
            {
                data[xx, yy] = value;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            BlockData b = new BlockData() { data = new int[1600, 1600] };
            b[10, 5] = 999;
            // (10,5) is in the 402nd block of 4x4 at (2,1) within that block.
            Debug.Assert(b[402, 2, 1] == 999);
            b[888, 3, 2] = 777;
            // The 888th block is row 2, column 88.  Its top-left is at ((88*4),(2*4)).
            // (352 + 3, 8 + 2) = (355, 10)
            Debug.Assert(b[355, 10] == 777);
        }
    }
