    public void DeleteBranchWithNoData()
    {
        var toBeRemoved = new List<Data>();
        foreach(var child in Children)
        {
            if(!child.HaveData && (child.Children == null || !child.Children.Any()))
            {
                toBeRemoved.Add(child);
            }
            else
            {
                child.DeleteBranchWithNoData();
            }   
        }
        Children.RemoveAll(d => toBeRemoved.Contains(d));
    }
