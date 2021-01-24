    foreach (DataRow item in dtDetails.Rows)
    {
      var pNameOriginal = dtProduct.AsEnumerable().FirstOrDefault(i => i.Field<int>("code") == item.Field<int>("code"));
      var globalName = "NotFound";
      if (pNameOriginal != null && !string.IsNullOrEmpty(Convert.ToString(pNameOriginal.ItemArray[1])))
      {
        globalName = Convert.ToString(pNameOriginal.ItemArray[1]);
      }
    
      item["pNameLocal"] += globalName;
    }
