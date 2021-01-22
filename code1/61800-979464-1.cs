    SPQuery oQuery = new SPQuery();
    oQuery.ViewFields = "<FieldRef Name='UrlColumn'/>";
    
    list.Items.GetItems(oQuery).GetDataTable();
    
    ...foreach code...
    row["UrlColumn"] 
