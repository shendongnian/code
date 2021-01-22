    var list = productQuery.ToList();
    var productList = Functions.sortResultsList(list);
     
    public static List<SolutionsModel.Version> 
       sortResultsList(List<SolutionsModel.Version> list)
    {
        var productList = new List<SolutionsModel.Version>();
        int total = list.Count();
        int solutions = 0;
        int objects = 0;
        for (int length = 0; length < list.Count(); length++)
        {
            if (list[length].Product.TypeID == 1)
            {
                ++solutions;
            }
            else if (list[length].Product.TypeID == 2)
            {
                ++objects;
            }
        }
        //These nested for-loops create a list that is 
        //correctly ordered to fit correctly into the grid. 
        //Perhaps consider more efficient improvision at a later time.
        //These for loops can't be used if there are not any solutions 
        //in the results
        if (solutions != 0)
        {
            for (int x = 0; x < list.Count; x++)
            {
                if (list[x].Product.TypeID == 1)
                {
                    productList.Add(list[x]);
                    for (int y = 0; y < list.Count; y++)
                    {
                        if (list[y].Product.TypeID != 1)
                        {
                            if (list[y].Product.Product2.ID == list[x].Product.ID && list[y].VersionNumber == list[x].VersionNumber)
                            {
                                productList.Add(list[y]);
                                for (int j = 0; j < list.Count; j++)
                                {
                                    if (list[j].Product.TypeID == 3)
                                    {
                                        if (list[j].Product.Product2.ID == list[y].Product.ID && list[j].VersionNumber == list[y].VersionNumber)
                                        {
                                            productList.Add(list[j]);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        //This can't be used if the results do not contain any objects.
        if (objects != 0 && productList.Count != total)
        {
            for (int y = 0; y < list.Count; y++)
            {
                if (list[y].Product.TypeID == 2)
                {
                    productList.Add(list[y]);
                    for (int j = 0; j < list.Count; j++)
                    {
                        if (list[j].Product.TypeID == 3)
                        {
                            if (list[j].Product.Product2.ID == list[y].productID && list[j].VersionNumber == list[y].VersionNumber)
                            {
                                productList.Add(list[j]);
                            }
                        }
                    }
                }
            }
        }
        //If the results contain only modules, no sorting is required and the original list can be used.
        if (productList.Count != total)
        {
              return list;
        }
        return productList;
    }
