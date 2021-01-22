    int[] arr = new [] { 1, 2, 3, 0, 1, 2, 3 };
    public override int GetHashCode()
    {
        if(arr.Length > 14) throw new Exception("max elems is 14");
        int hash = 1; // start with 1 to take into account a heading 0
        foreach (int i in arr)
        {
            hash = hash << 2;
            hash += i;
        }
        return hash;
    }
