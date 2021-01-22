        GridViewItemList.DataSource = listToDisplay.Select(x => new 
                                     {
                                         Id = x.Id,
                                         Name = x.Name                                         
                                     })
                                     .ToList();
        GridViewItemList.DataBind();
