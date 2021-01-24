    var defaultSelectedRow = myDataTable.AsEnumerable()
                                        .Where(x => x.Field<string>("colA") == "aaa")
                                        .OrderBy(y => y.Field<string>("dateof")).FirstOrDefault();
    if (defaultSelectedRow != null)
    {
        string colBValue = defaultSelectedRow.Field<string>("colB");
    }
