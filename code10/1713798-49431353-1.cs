        ISet<string> two = new HashSet<string>();
        List<DataTableDetails> dtdetaills=new List<DataTableDetails>();
         Parallel.ForEach(OneTwoThree , One=>
                     {
                         dt.Columns.Add(One.Key);
                         foreach(var Two in One.Value)
                         { 
                          two.Add(Two.Key); // To get Distinct Values
                         }
                     });
    int count=0;
    foreach(var item in two)
     { 
       var row = dt.NewRow();
       row["TwoDetails"] = row;
       DataTableDetails details = new DataTableDetails();
       details.RowName = item;
       details.RowNumber = count++; // we can easily get row number 
       dtdetails.Add(details);
     }
