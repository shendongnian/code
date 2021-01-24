    var dt = new DateTable();
    
      dt.Columns.Add(Header1, typeof(int));
      dt.Columns.Add(Header2, typeof(string));
      dt.Columns.Add(Header3, typeof(string));
    foreach(var item in list)
    {
      dt.Rows.Add(item.value1,item.value2,item.value3);
    }
