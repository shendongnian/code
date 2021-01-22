    class Program
    {
        static void Main(string[] args)
        {
            const int testLength = 30000;
            var StartTime = DateTime.Now;
            //TEST 1 - String
            StartTime = DateTime.Now;
            String tString = "test string";
            for (int i = 0; i < testLength; i++)
            {
                tString += i.ToString();
            }
            Console.WriteLine((DateTime.Now - StartTime).TotalMilliseconds.ToString());
            //result: 2000 ms
            //TEST 2 - StringBuilder
            StartTime = DateTime.Now;
            StringBuilder tSB = new StringBuilder("test string");
            for (int i = 0; i < testLength; i++)
            {
                tSB.Append(i.ToString());
            }
            Console.WriteLine((DateTime.Now - StartTime).TotalMilliseconds.ToString());
            //result: 4 ms
            Console.ReadLine();
        }
    }
