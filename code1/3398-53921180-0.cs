    if (model.SortColumnName.HasValue())
    {
         switch (model.SortType)
         {
             case SortType.Asc:
                 all = all.OrderBy($"{model.SortColumnName} ASC");
                 break;
             case SortType.Desc:
                 all = all.OrderBy($"{model.SortColumnName} DESC");
                 break;
         }
    }
