    StreamReader one = new StreamReader("C:\file1.csv");
    StreamReader two = new StreamReader("C:\file2.csv");
    String lineOne;
    String lineTwo;
    StreamWriter differences = new StreamWriter("Output.csv");
    lineOne = one.ReadLine();
    lineTwo = two.ReadLine();
    while (!one.EndOfStream || !two.EndOfStream)
    {
      if(lineOne == lineTwo)
      {
        // lines match, read next line from each and continue
        lineOne = one.ReadLine();
        lineTwo = two.ReadLine();
        continue;
      }
      if(two.EndOfStream || lineOne < lineTwo)
      {
        differences.WriteLine(lineOne);
        lineOne = one.ReadLine();
      }
      if(one.EndOfStream || lineTwo < lineOne)
      {
        differences.WriteLine(lineTwo);
        lineTwo = two.ReadLine();
      }
    }
