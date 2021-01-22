    MarketValueDataTable mv = new MarketValueDataTable();
    foreach(DataRow row in table.Rows)
    {
    
       MarketValueDataTableRow mvrow = mv.NewRow();
       foreach(DataColumn col in table.Columns)
       {
          PropertyInfo colProperty = mvrow.GetType().GetProperty(col.Name);
          colProperty.SetValue(mvRow, row[col]);
       }
       mv.Rows.Add(mvrow);
    
    }
