    foreach (string line in File.ReadLines(@"C:\INPUTFILE.txt"))
    {
        if (line.Contains("CERTAINWORD"))
        {
            Console.WriteLine(line);
        }
    }
