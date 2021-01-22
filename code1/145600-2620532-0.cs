        int amt = 73;
        Dictionary<int, int> dic = new Dictionary<int, int>() {{20,0},{10,0},{5,0},{1,0}};
        int[] keys =new  int[dic.Count];
        dic.Keys.CopyTo(keys, 0);
        foreach (int i in  keys)
        {            
            if (amt >= i)
            {
                dic[i] = amt / i;
                amt = amt % i;
            }
        }
