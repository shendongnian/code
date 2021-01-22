    DateTime startDate = DateTime.Today.AddDays(11);
    DateTime endDate = DateTime.Today.AddDays(15);
     
    SPList taskList = web.Lists["Tasks"];
     
    SPQuery query = new SPQuery();
    query.ViewFields = "<FieldRef Name='Title'/><FieldRef Name='StartDate'/><FieldRef Name='DueDate'/>";
    query.Query = BuildDateRangeOverlapFilter(startDate, endDate);
     
    SPListItemCollection matches = taskList.GetItems(query);
     
    foreach (SPListItem match in matches)
    {
        Console.WriteLine(match["Title"]);
    }
