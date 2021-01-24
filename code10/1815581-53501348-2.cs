    using(StreamWriter SW = new StreamWriter("important.txt"))
    {
        foreach(Emplooye i in group1)
        {
            SW.WriteLine(i.ToString());
        }
        foreach(Emplooye i in group2)
        {
            SW.WriteLine(i.ToString());
        } 
        foreach(Emplooye i in group3)
        {
            SW.WriteLine(i.ToString());
        }
    }
