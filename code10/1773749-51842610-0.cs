    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Image img = e.Row.FindControl("Image1") as Image;
            if (nestedSource == 0) {
                img.ImageUrl = "images/min.png";
            }
            else
            {
                img.Attributes.Add("style", "cursor:pointer");
            }
        }
    }
