    public List<IMyClass> Fill(string[] ItemsPassedByParam)
    {
        List MyList = new List<IMyClass>();
        
        foreach (item in ItemsPassedByParam)
        {
            MyList.Add(IMyClassFactory.CreateInstance(item));
        }
    }
