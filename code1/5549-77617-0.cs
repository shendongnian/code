    StreamReader one = new StreamReader("C:\file1.csv");
    StreamReader two = new StreamReader("C:\file2.csv");
    String lineOne;
    String lineTwo;
    
    StreamWriter differences = new StreamWriter("Output.csv");
    while (!one.EndOfStream)
    {
        lineOne = one.ReadLine();
        lineTwo = two.ReadLine();
        // do your comparison.
        bool areDifferent = true;
    
        if (areDifferent)
            differences.WriteLine(lineOne + lineTwo);
    }
    
    one.Close();
    two.Close();
    differences.Close();
