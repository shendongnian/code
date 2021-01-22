    StreamReader convert = new StreamReader("filename.txt");
    string line = convert.ReadLine();
    while (line != null)
    {
        string[] measurementArray = line.Split(',');
        Console.WriteLine("{0}", measurementArray[0]);
        Console.WriteLine("{0}", measurementArray[1]);
        line = convert.ReadLine();
    }
