            //Case 1: Category and Type
            var caretoryTypeResult = (from b in dt.AsEnumerable()
                                  group b by new
                                  {
                                      Category = b.Field<string>("Category"),
                                      Type = b.Field<string>("Type")
                                  }
                                      into grpCategoryType
                                      select new
                                      {
                                          grpCategoryType.Key.Category,
                                          grpCategoryType.Key.Type,
                                          grpCategoryType
                                      }).ToList();
            caretoryTypeResult.ForEach(list => {
                var category = list.grpCategoryType.AsEnumerable().Select(m => m.Field<string>("Id")).ToList();
                dtNew.Rows.Add(string.Join(",", category), list.Category, list.Type);
                
            });
