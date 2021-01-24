    public List<int> BinaryList(string digits)
    {
        List<int> binaryList = new List<int>();
    
        foreach(var index in digits)
        {
            binaryList.Add(int.Parse(index.ToString()));
        }
    
            return binaryList;
    }
