    private void GenerateExcelFile(DataSet dst, string fileName)
        {
    		// Clear any current output from the buffer.
    		Response.Clear();
    
    		// "Content-Disposition" & "attachment;filename=" are used to specify the default filename for the downloaded file.
          Response.AddHeader("Content-Disposition", "attachment;filename=" + fileName);
    		Response.ContentType = "application/vnd.ms-excel";
    
            DataView dvw = dst.Tables[0].DefaultView;
    
    		if ((dvw != null) && (dvw.Table.Rows.Count > 0))
    		{
    			// We're exporting an HTML table.
    			Table tbl = ConvertDataViewToHTMLTable(dvw);
    
    			StringWriter sw = new StringWriter();
    			HtmlTextWriter hw = new HtmlTextWriter(sw);
    			tbl.RenderControl(hw);
    			Response.Write(sw.ToString());
    			Response.End();
    		}
        }
  
        private Table ConvertDataViewToHTMLTable(DataView dvw)
    	{
    		Table tbl = new Table();
    		TableRow trw;
    		TableCell tcl;
    		Label lbl;
    		DataColumn col;
    
    		tbl.BorderColor = Color.Black;
    		tbl.BorderWidth = Unit.Pixel(1);
    		tbl.BorderStyle = BorderStyle.Solid;
    
    		// Begin with a table row containing column names.
    		trw = new TableRow();
    
    		for (int i = 0; i < dvw.Table.Columns.Count; i++)
    		{
    			col = dvw.Table.Columns[i];
    
    			// Add column name.
    			lbl = new Label();
    			lbl.Text = col.ColumnName;
    
    			tcl = new TableCell();
    			tcl.Controls.Add(lbl);
    
    			tcl.BackColor = Color.MediumSeaGreen;
    			tcl.ForeColor = Color.PaleGoldenrod;
    			tcl.HorizontalAlign = HorizontalAlign.Center;
    			tcl.Style["Font"] = "Tahoma";
    			tcl.Style["Font-Weight"] = "Bold";
    
    			trw.Controls.Add(tcl);
    		}
    
    		tbl.Controls.Add(trw);
    
    		// Add records containg row data.
    		DataRow row;
    		for (int i = 0; i < dvw.Table.Rows.Count; i++)
    		{
    			row = dvw.Table.Rows[i];
    
    			trw = new TableRow();
    
    			for (int j = 0; j < dvw.Table.Columns.Count; j++)
    			{
    				col = dvw.Table.Columns[j];
    
    				lbl = new Label();
    				lbl.Text = row[col.ColumnName].ToString();
    
    				tcl = new TableCell();
    				tcl.Controls.Add(lbl);
    				tcl.BorderColor = Color.LightGray;
    				tcl.BorderWidth = Unit.Pixel(1);
    				tcl.Style["Font"] = "Tahoma";
    
    				trw.Controls.Add(tcl);
    
    			}
    			tbl.Controls.Add(trw);
    		}
    
    		return tbl;
    	}
