    //ASSUMPTION: All tables must have the same columns
    var tables = new List<DataTable>();
	tables.Add(oneTableToRuleThemAll);
    tables.Add(oneTableToFindThem);
    tables.Add(oneTableToBringThemAll);
	tables.Add(andInTheDarknessBindThem);
    //Or in the real world, you might be getting a collection of tables from some abstracted data source.
    
    //behold, a table too great and terrible to imagine
    var theOneTable = tables.SelectMany(dt => dt.AsEnumerable()).CopyToDataTable();
