    private List<int> categoryIDs = null;
    List<int> CategoryIDs
    {
        get
        {
            if (categoryIDs == null)
            {
                categoryIDs = new List<int>();
                GetCategoryList().Split(',').ToList().ForEach(id => categoryIDs.Add(Convert.ToInt32(id)));
            }
            return(categoryIDs);
        }
        set
        {
            List<string> stringList = value.ConvertAll<string>(i => i.ToString());
            SetCategoryList(String.Join(",", stringList.ToArray()));
        }
    }
    public string GetCategoryList()
    {
        throw new NotImplementedException();
    }
    public void SetCategoryList(string categoryList)
    {
        throw new NotImplementedException();
    }
