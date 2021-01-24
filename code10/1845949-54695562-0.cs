    protected void Button2_Click(object sender, EventArgs e)
    {
        string id = GridView1.SelectedRow.Cells[3].Text;
    }
    
    // only allow the button to be enabled if there is a selected row
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {        
        if (GridView1.SelectedRow != null){
            Button2.Enabled = true;
        } else {
            Button2.Enabled = false;
        }
    }
