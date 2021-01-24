    protected void ScoreChanged (object sender, EventArgs e)
    {
        DropDownList ddl = (DropDownList)sender;
        int score = ddl.SelectedIndex;
        (TableCell tc1, TableCell t2) = ((TableCell, TableCell))ddl.Tag;
        if(score < 2)
        {
            tc1.Visible = false;
            tc2.Visible = false;
        }
        else
        {
            tc1.Visible = true;
            tc2.Visible = true;
        }
    }
