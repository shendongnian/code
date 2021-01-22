    string line = reader2.ReadLine();
    
    while (!reader2.EndOfStream)
    {
        writer2.WriteLine(line);
        line = reader2.ReadLine();
    } // by reading ahead, will not write last line to file 
