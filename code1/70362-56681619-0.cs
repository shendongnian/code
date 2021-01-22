    DataTable results = MyMethod.GetResults();
    if(results != null && results.Rows.Count > 0)  // Check datatable is null or not
    {
      List<string> lstring = new List<string>();
      foreach(DataRow dataRow in dt.Rows)
      {
         lstring.Add(Convert.ToString(dataRow["ColumnName"]));
      }
      string mainresult = string.Join(",", lstring.ToArray()); // You can Use comma(,) or anything which you want. who connect the two string. You may leave space also.
    }
    Console.WriteLine (mainresult);
                    
                    
