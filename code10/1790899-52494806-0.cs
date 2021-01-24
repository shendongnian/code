    protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView dr = (DataRowView)e.Row.DataItem;
            if (dr["Image"] != DBNull.Value)
            {
                var imageControl = e.Row.FindControl("Image1") as Image;
                var encodedImage = Convert.ToBase64String((byte[])dr["Image"]);
                string imageUrl = "data:image/jpg;base64," + encodedImage);
                imageControl.ImageUrl = imageUrl;
            }
        }
    }
