        if (sortOrder == 1)
        {
            columnData = columnData.OrderBy(s => s);//.ToList();
        }
        else
        {
            columnData = columnData.OrderByDescending(s => s);//.ToList();
        }
