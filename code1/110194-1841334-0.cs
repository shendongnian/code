    public void Split(ref UList list)
    {
        string[] s = list.mylist.ToArray();
        //split the array into top and bottom halfs
        string[] top = new string[s.Length / 2];
        string[] bottom = new string[s.Length - s.Length / 2];
        Array.Copy(s, top, top.Length);
        Array.Copy(s, top.Length, bottom, 0, bottom.Length);
        Console.WriteLine("Top: ");
        foreach (string item in top) Console.WriteLine(item);
        Console.WriteLine("Bottom: ");
        foreach (string item in bottom) Console.WriteLine(item);
    }
