    protected void gvVarianceReport_Sorting(object sender, GridViewSortEventArgs e)
    {
        if (e.Row.Cells[2].Text == "0")
        {
            e.Row.Cells[2].Text = "N/A";
            e.Row.Cells[3].Text = "N/A";
            e.Row.Cells[4].Text = "N/A";
        }
    }
