    protected void RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.Parent.Parent.ID == "GridView1")
        {
            //do 1% for GridView1
        }
        else
        {
            //do 1% for GridView2
        }
    }
