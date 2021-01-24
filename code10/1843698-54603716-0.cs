    public void UploadImage(PictureBox image, string filename)
    {
        string filepath = image.ImageLocation;     //<= Get image path 
        using (WebClient client = new WebClient())
        {
            client.Credentials = new NetworkCredential(ftpUsername, ftpPassword);
            client.UploadFile("ftp://127.0.0.1/Image/", filepath);    //<= Pass this path here
    
        }
    }
