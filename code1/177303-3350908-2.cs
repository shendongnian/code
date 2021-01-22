    // loop through your data and find the largest common size (note: you can use LINQ)
    int maxCol1 = 0;
    int maxCol2 = 0;
    foreach(item in yourData)
    {
        maxCol1 = item.Col1 > maxCol1 ? item.Col1 : maxCol1;
        maxCol2 = item.Col2 > maxCol2 ? item.Col2 : maxCol2;
    }
    // create formatting strings, add all sizes:
    string line = new String('-', 2 + maxCol1 + maxCol2 + nr of columns ...);
    string formatString = String.Format(
          "|{{0,-{0}}}|{{1,-{1}}}|{{2,-{2}}}|)", 
          maxCol1,maxCol2 ...);
    
    // create your text-only mail neatly formatted
    yourStringWriter.WriteLine(line);
    foreach(item in yourData)
    {
        yourStringWriter.WriteLine(String.Format(formatString, item.Col1, item.Col2);
        yourStringWriter.WriteLine(line);
    }
