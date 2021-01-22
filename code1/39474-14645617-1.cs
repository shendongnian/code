    static void Main(string[] args)
    {
            const int TEST_COUNT = 10000;
            const int BUFFER_LENGTH = 100000;
            Random random = new Random();
            Stopwatch sw = new Stopwatch();
            Stopwatch sw2 = new Stopwatch();
            byte[] buffer = new byte[BUFFER_LENGTH];
            random.NextBytes(buffer);
            sw.Start();
            for (int j = 0; j < TEST_COUNT; j++)
                HexTable.ToHexTable(buffer);
            sw.Stop();
            sw2.Start();
            for (int j = 0; j < TEST_COUNT; j++)
                ToHexChar.ToHex(buffer);
            sw2.Stop();
            Console.WriteLine("Hex Table Elapsed Milliseconds: {0}", sw.ElapsedMilliseconds);
            Console.WriteLine("ToHex Elapsed Milliseconds: {0}", sw2.ElapsedMilliseconds);
        }
