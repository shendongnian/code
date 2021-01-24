    public List<List<MyClass>> MyConvert(List<List<List<MyClass>>> items)
    {
        Dictionary<string, List<MyClass>> resultsDic = new Dictionary<string, List<MyClass>>();
        foreach (List<List<MyClass>> item in items)
        {
            foreach (List<MyClass> innerItem in item)
            {
                foreach (MyClass myClass in innerItem)
                {
                    if (!resultsDic.ContainsKey(myClass.Key))
                    {
                        resultsDic.Add(myClass.Key, innerItem);
                    }
                }
            }
    
        }
        List<List<MyClass>> convertedResults = resultsDic.Select(x => x.Value).ToList();
        return convertedResults;
    }
