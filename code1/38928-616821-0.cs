    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            var some = (Foo.SomeBar) e.Row.DataItem;
            somelabel.Text = some.Date.ToString();
        }
    }
