    string line;
    List<uint> binaryValues = new List<uint>();
    using (StreamReader file = new StreamReader(@"c:\test.txt"))
        while((line = file.ReadLine()) != null)
            Console.WriteLine(Convert.ToUint32(line, 16));
    Console.ReadLine();
