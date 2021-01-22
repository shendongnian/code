    try
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (((DataRowView)(e.Row.DataItem))["Columnname"].ToString().Equals("Total", StringComparison.OrdinalIgnoreCase))
            {
                e.Row.Font.Bold = true;
                //-----or ant thing you want to do------
            }
        }
    }
    catch (Exception ex)
    {
    
    }
       
