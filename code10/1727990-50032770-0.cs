	int row = GridView1.Rows.Count - 1;
    String val = GridView1.Rows[row].Cells[1].Text.ToString();
	
	bool errorFound = false;
    foreach (GridViewRow rows in GridView2.Rows)
    {
        for (int i = 0; i < GridView2.Columns.Count; i++)
        {
            //String header = GridView2.Columns[i].HeaderText;
            String cellText = rows.Cells[i].Text;
            if (val == cellText)
            {
				errorFound = true;
                lblError.Text = "ID number already assigned!!";
            }
        }
    }
	
    if (GridView2.Rows.Count >= 0 && !errorFound)
    {
        DataRow dr = dt.NewRow();
        dr["StudentName"] = GridView1.Rows[row].Cells[0].Text;
        dr["IDNum"] = GridView1.Rows[row].Cells[1].Text;
        dt.Rows.Add(dr);
    }
