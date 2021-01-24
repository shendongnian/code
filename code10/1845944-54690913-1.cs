    protected void Button2_Click(object sender, EventArgs e)
    {
        string id = SelectedId;
    }
    private string SelectedId 
    {
      get
      {
        GridViewRow row = GridView1.SelectedRow;
        return row?.Cells[3].Text; // Please note the check against null (row?)
      }
    }
