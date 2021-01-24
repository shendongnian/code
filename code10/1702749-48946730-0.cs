    public Hashtable function(ArrayList aList)
    {
        Hashtable hTable = new Hashtable();        
        int i = 0;
        foreach (var item in aList)
        {
            if (!hTable.Contains(item))
                hTable.Add(i,item);
            i++;
        }
        return hTable;
    }
