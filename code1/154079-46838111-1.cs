    //== the button click method
    protected void Button1_Click(object sender, EventArgs e)
    {
        //check if there is an actual file being uploaded
        if (FileUpload1.HasFile == false)
        {
            return;
        }
        using (Bitmap bitmap = new Bitmap(FileUpload1.PostedFile.InputStream))
        {
            try
            {
                //start the resize
                Image image = resizeImage(bitmap, 256, 256, true);
                //to visualize the result, display as base64 image
                Label1.Text = "<img src=\"data:image/jpg;base64," + convertImageToBase64(image) + "\">";
                //save your image to file sytem, database etc here
            }
            catch (Exception ex)
            {
                Label1.Text = "Oops! There was an error when resizing the Image.<br>Error: " + ex.Message;
            }
        }
    }
