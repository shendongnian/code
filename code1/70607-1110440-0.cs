    ArrayList data = new ArrayList();
    data.Add(1);
    data.Add("a string");
    data.Add(DateTime.Now);
    
    Dictionary<Type, Object> dataDictionary = new Dictionary<Type, object>();
    for (int i = 0; i < data.Count; i++)
    {
        dataDictionary.Add(data[i].GetType(), data[i]);
    }
