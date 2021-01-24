    public List<object[]> GetProdVal()
    {
        List<object[]> value = new List<object[]>();
        foreach (var item in valuelist)
        {
            object[] val = {
            $"new Date('{item.Date.ToString("yyyy-MM-ddThh:mm:ss")}')",
            item.TotalCost
            };
            value.Add(val);
        }
        return value;
    }
