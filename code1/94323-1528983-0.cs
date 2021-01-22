    string categoryIDList = Convert.ToString(reader["categoryIDList"]);
    if (!String.IsNullOrEmpty(categoryIDList))
    {
        c.CategoryIDList  =
            new List<int>(
                categoryIDList.Split(',').Select(s => Convert.ToInt32(s))
            );
    }
