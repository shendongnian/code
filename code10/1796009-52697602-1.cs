    @foreach (var data in Model)
    {
        if(data.GetAllProductsGroupByType != null || data.GetAllProductsGroupByType.Count == 0)
        {
            continue;
        }
        foreach(var item in data.GetAllProductsGroupByType)
        {
           <li>item</li>
        }
    }
