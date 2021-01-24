    int row = GridView1.Rows.Count - 1;
    String val = GridView1.Rows[row].Cells[1].Text.ToString();
    bool idFound = false;
    foreach (GridViewRow rows in GridView2.Rows)
    {
        //Get the Text of 2nd Cell in cellText Variable.
        String cellText = rows.Cells[1].Text;
        if (val == cellText)
        {
            //Display error message and set idFound value to true.
            lblError.Text = "ID number already assigned!!";
            idFound = true;
        }
    }
    
    //Check value of idFound, if it is false then add row to GridView1
    if (!idFound)
    {
        DataRow dr = dt.NewRow();
        dr["StudentName"] = GridView1.Rows[row].Cells[0].Text;
        dr["IDNum"] = GridView1.Rows[row].Cells[1].Text;
        dt.Rows.Add(dr);
    }
