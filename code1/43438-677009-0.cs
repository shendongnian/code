    Dictionary<int,int> dic=new Dictionary<int, int>();
    //...fill the dictionary
    
    int[] keys = dic.Keys.ToArray();
    foreach (int i in keys)
    {
        dic.Remove(i);
    }
