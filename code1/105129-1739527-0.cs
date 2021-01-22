    protected void GridView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        CheckBox chk = (CheckBox)e.Row.FindControl("CheckBox1");
        if (chk != null)
        {
            Image img1 = (Image)e.Row.FindControl("Image1");
            if (chk.Checked)
                img1.ImageUrl = "greenimage.jpg";
            else
                img1.ImageUrl =  "redimage.jpg";
        }
    }
