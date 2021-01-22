        static void Main()
        {
            // sample data
            File.WriteAllText("my.data", @"4 6
    1 2 3 4 5 6
    2 5 4 3 21111 101
    3 5 6234 1 2 3
    4 2 33434 4 5 6");
            using (Stream s = new BufferedStream(File.OpenRead("my.data")))
            {
                int rows = ReadInt32(s), cols = ReadInt32(s);
                int[,] arr = new int[rows, cols];
                for(int y = 0 ; y < rows ; y++)
                    for (int x = 0; x < cols; x++)
                    {
                        arr[y, x] = ReadInt32(s);
                    }
            }
        }
        private static int ReadInt32(Stream s)
        {
            int b = s.ReadByte();
            if(b<0)throw new EndOfStreamException();
            while (b == '\n' || b == '\r') { b = s.ReadByte(); }
            if (b < '0' || b > '9') throw new FormatException();
            int result = b - '0';
            while ((b = s.ReadByte()) >= '0' && b <= '9')
            {
                result = result * 10 + (b - '0');
            }
            return result;
        }
