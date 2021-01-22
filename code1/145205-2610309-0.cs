    private void ButtonUpload_Click(object sender, System.EventArgs e)  {
    
        //Determine type and filename of uploaded image
        string UploadedImageType = UploadedPicture.PostedFile.ContentType.ToString().ToLower();
        string UploadedImageFileName = UploadedPicture.PostedFile.FileName;
    
        //Create an image object from the uploaded file
        System.Drawing.Image UploadedImage = System.Drawing.Image.FromStream(UploadedPicture.PostedFile.InputStream);
    
        //Determine width and height of uploaded image
        float UploadedImageWidth = UploadedImage.PhysicalDimension.Width;
        float UploadedImageHeight = UploadedImage.PhysicalDimension.Height;
    
        //Check that image does not exceed maximum dimension settings
        if (UploadedImageWidth > 600 || UploadedImageHeight > 400) {
                Response.Write("This image is too big - please resize it!");
        }
    
    }
