    StreamWriter writer = new StreamWriter(File.Create(dir + "\\schema.ini"));
    writer.WriteLine("[" + fileToBeRead + "]");
    writer.WriteLine("ColNameHeader = False");
    writer.WriteLine("Format = CSVDelimited");
    writer.WriteLine("CharacterSet=ANSI");
    int iColCount = dTable.Columns.Count + 1;
    for (int i = 1; i < iColCount; i++)
    {
        writer.WriteLine("Col" + i + "=Col" + i + "Name Char Width 20");
    }
    //writer.WriteLine("Col1=Col1Name Char Width 20");
    //writer.WriteLine("Col2=Col1Name Char Width 20");
    //etc.
    writer.Close();
