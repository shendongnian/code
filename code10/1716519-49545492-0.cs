    public List<SomeObj> LoadSomeData(List<int> listOfIds)
    {
        using (var context = new DataContext())
        {
            return context.SomeObj.Where(x => listOfIds.Contains(x.id)).ToList();
        }
    }
