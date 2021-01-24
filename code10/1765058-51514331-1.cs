    if (dt.Rows.Count > 0)
                {
                    var vCategory = (from x in dt.AsEnumerable()
                                     group x by new
                                     {
                                         Category = x.Field<string>("Category"),
                                         Type = x.Field<int>("Type")
                                     }
                                     into grp
                                     select new
                                     {
                                         grp.Key.Category,
                                         grp.Key.Type,
                                         grp
                                     }).ToList();
                    foreach (var singleCatagory in vCategory)
                    {
                        List<int> singleCatagoryList = singleCatagory.grp.AsEnumerable().Select(x => x.Field<int>("ID")).ToList();
                        dtCategory.Rows.Add(string.Join(",", singleCatagoryList), singleCatagory.Category, singleCatagory.Type);
                    }
                }
