    IEnumerable<object> Search(string yourLookup)
    {
        foreach(Column column in yourGridInstance.Columns)
        {
           if(column.DisplayText.Equals(yourLookup, yourStringcomparaisonOptions)
           {
              foreach(T value in yourGridInstance.DataSource)
              {
                 yield return column.Rowdata(T);
              }
           }
        }
    }
