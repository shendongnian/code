    using (StreamWriter result = new StreamWriter("result.txt"))
    {
        StreamReader file1 = new StreamReader("file1.txt");
        StreamReader file2 = new StreamReader("file2.txt");
        StreamReader file3 = new StreamReader("file3.txt");
        while (!file1.EndOfStream || !file2.EndOfStream || !file3.EndOfStream)
        {
            result.Write(file1.ReadLine() ?? "");
            result.Write(file2.ReadLine() ?? "");
            result.WriteLine(file3.ReadLine() ?? "");
        }
    }
