     protected void RowDataBound(object sender, GridViewRowEventArgs e)
     {   
                DataRowView drv = (DataRowView)e.Row.DataItem;
                if (drv["INVOICES/RECEIPTS "].ToString()) == "INVOICE" )
                {
                e.Row.Attributes.Remove("Class");
                e.Row.Attributes.Add("Class", "GridView_New");
                }
      }
