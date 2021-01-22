    string str = line.Substring(0,1);
    int i = -1;
    if (Int32.TryParse(str, out i))
    {
       Console.WriteLine(i);
    }
