    System.IO.StreamReader sr = new System.IO.StreamReader(filename);
    while (!sr.EndOfStream)
    {
        string line = sr.ReadLine(); // or other method reading a block 
        //Do something whith the line
    }
    sr.Close();
    sr.Dispose();
