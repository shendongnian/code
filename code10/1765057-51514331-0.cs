    DataTable dtCategory = new DataTable();
            dtCategory.Columns.Add("ID");
            dtCategory.Columns.Add("Category");
            dtCategory.Columns.Add("Type");
            dtCategory.Columns.Add("Parameter1");
            if (dt.Rows.Count > 0)
            {
                var vCategory = (from x in dt.AsEnumerable()
                                 group x by x.Field<string>("Category") into grp
                                 select new
                                 {
                                     Category = grp.Key,
                                     grp
                                 }).ToList();
                foreach (var singleCatagory in vCategory)
                {
                    List<int> singleCatagoryList = singleCatagory.grp.AsEnumerable().Select(x => x.Field<int>("ID")).ToList();
                    dtCategory.Rows.Add(string.Join(",", singleCatagoryList),singleCatagory.Category);
                }
            }
