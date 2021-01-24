       List<double> list = new List<double>();          
       foreach (var row in dt.AsEnumerable())
       {
           if (row.ItemArray[0] != DBNull.Value)
           {
               list.Add(Convert.ToDouble(row.ItemArray[0]));
            }
    
        }    
