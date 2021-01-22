    private static void TestMethod()
    {
        Random rnd = new Random(DateTime.Now.Millisecond);
        string Pattern = "-------------------------------65498495198498";
        byte[] pattern = Encoding.ASCII.GetBytes(Pattern);
    
        byte[] testBytes;
        int count = 3;
        for (int i = 0; i < 100; i++)
        {
            StringBuilder TestString = new StringBuilder(2500);
            TestString.Append(Pattern);
            byte[] buf = new byte[1000];
            rnd.NextBytes(buf);
            TestString.Append(Encoding.ASCII.GetString(buf));
            TestString.Append(Pattern);
            rnd.NextBytes(buf);
            TestString.Append(Encoding.ASCII.GetString(buf));
            TestString.Append(Pattern);
            testBytes = Encoding.ASCII.GetBytes(TestString.ToString());
    
            List<int> idx = IndexOfSequence(ref testBytes, pattern, 0);
            if (idx.Count != count)
            {
                Console.Write("change from {0} to {1} on iteration {2}: ", count, idx.Count, i);
                foreach (int ix in idx)
                {
                    Console.Write("{0}, ", ix);
                }
                Console.WriteLine();
                count = idx.Count;
            }
        }
    
        Console.WriteLine("Press ENTER to exit");
        Console.ReadLine();
    }
