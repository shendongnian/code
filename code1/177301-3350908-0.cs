    // loop through your data and find the largest common size (note: you can use LINQ)
    int commonSizeCol1 = 0;
    int commonSizeCol2 = 0;
    foreach(item in yourData)
    {
        commonSizeCol1 = item.Col1 > commonSizeCol1 ? item.Col1 : commonSizeCol1;
        commonSizeCol2 = item.Col2 > commonSizeCol2 ? item.Col2 : commonSizeCol2;
    }
    // create formatting strings, add all sizes:
    string line = new String("-", 2 + commonSizeCol1 + commonSizeCol2 + nr of columns ...);
    string formatString = String.Format(
          "|{{0,-{0}}}|{{1,-{1}}}|{{2,-{2}}}|)", 
          commonSizeCol1, commonSizeCol2 ...);
    
    // create your text-only mail neatly formatted
    yourStringWriter.WriteLine(line);
    foreach(item in yourData)
    {
        yourStringWriter.WriteLine(String.Format(formatString, item.Col1, item.Col2);
        yourStringWriter.WriteLine(line);
    }
