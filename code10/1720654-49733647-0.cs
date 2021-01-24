    protected void gridview1_HtmlDataCellPrepared(object sender, DevExpress.Web.ASPxGridViewTableDataCellEventArgs e)
        {
            if (e.DataColumn.FieldName == "c04_oprogrs")
            {
                if (e.CellValue != null)
                    if (e.CellValue.ToString()=="1")
                    {
                       
                        e.Cell.Text = "Take ";
                    }
    
    		if (e.CellValue.ToString()=="2")
                    {
                       
                        e.Cell.Text = "Available ";
                    }        
             }
        }
