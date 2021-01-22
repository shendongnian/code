    void addOrUpdate(Dictionary<int, int> dic, int key, int newValue)
    {
        int val;
        if (dic.TryGetValue(key, out val))
        {
            // yay, value exists!
            dic[key] = val + newValue;
        }
        else
        {
            // darn, lets add the value
            dic.Add(key, newValue);
        }
    }
