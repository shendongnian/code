    static void Main(string[] args)
    {
        Stopwatch sw1 = new Stopwatch();
        Stopwatch sw2 = new Stopwatch();
        Stopwatch sw3 = new Stopwatch();
        sw1.Start();                            //first version: opens and closes file each time -> takes around 1 minute total
        for (int i = 0; i < 10000; i++)
        {
            using (System.IO.StreamWriter file1 =
                new System.IO.StreamWriter(@"C:\Outputtests\OutputTest1.txt", true))
            {
                file1.WriteLine(i);
            }
        }
        sw1.Stop();
        sw2.Start();                            //second version: flushes each time -> takes around 50ms
        StreamWriter file2 = File.CreateText(@"C:\Outputtests\OutputTest2.txt");
        for (int i = 0; i < 10000; i++)
        {
            file2.WriteLine(i);
            file2.Flush();
        }
        file2.Close();
        sw2.Stop();
        sw3.Start();                            //third version: flushes at the end -> takes around 10ms
        StreamWriter file3 = File.CreateText(@"C:\Outputtests\OutputTest3.txt");
        for (int i = 0; i < 10000; i++)
        {
            file3.WriteLine(i);
        }
        file3.Flush();
        file3.Close();
        sw3.Stop();
        Console.WriteLine("Output 1:\t" + sw1.ElapsedMilliseconds.ToString() + Environment.NewLine + "Output 2:\t" + sw2.ElapsedMilliseconds.ToString() + Environment.NewLine + "Output 3:\t" + sw3.ElapsedMilliseconds.ToString());
        Console.ReadKey();
    }
