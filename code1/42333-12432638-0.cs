    protected void btnUploadImage_OnClick(object sender, EventArgs e)
    {
        if (fil.FileBytes.Length > 51200)
        {
             TextBoxMsg.Text = "file size must be less than 50KB";
        }
    }
