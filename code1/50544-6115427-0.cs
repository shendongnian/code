		DataTable dt = new DataTable();
		
		// add the columns to the datatable            
		if (GridView1.HeaderRow != null)
		{
		
		    for (int i = 0; i < GridView1.HeaderRow.Cells.Count; i++)
		    {
		        dt.Columns.Add(GridView1.HeaderRow.Cells[i].Text);
		    }
		}
		
		//  add each of the data rows to the table
		foreach (GridViewRow row in GridView1.Rows)
		{
		    DataRow dr;
		    dr = dt.NewRow();
		
		    for (int i = 0; i < row.Cells.Count; i++)
		    {
		        dr[i] = row.Cells[i].Text.Replace("&nbsp;","");
		    }
		    dt.Rows.Add(dr);
		}
		
		//  add the footer row to the table
		if (GridView1.FooterRow != null)
		{
		    DataRow dr;
		    dr = dt.NewRow();
		
		    for (int i = 0; i < GridView1.FooterRow.Cells.Count; i++)
		    {
		        dr[i] = GridView1.FooterRow.Cells[i].Text.Replace("&nbsp;","");
		    }
		    dt.Rows.Add(dr);
		}
