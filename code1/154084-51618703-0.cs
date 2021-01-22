    protected void Button1_Click(object sender, EventArgs e)
    {
        //----------        Getting the Image File
        System.Drawing.Image img = System.Drawing.Image.FromFile(Server.MapPath("~/profile/Avatar.jpg"));
          
        //----------        Getting Size of Original Image
        double imgHeight = img.Size.Height;
        double imgWidth = img.Size.Width;
    
        //----------        Getting Decreased Size
        double x = imgWidth / 200;
        int newWidth = Convert.ToInt32(imgWidth / x);
        int newHeight = Convert.ToInt32(imgHeight / x);
    
        //----------        Creating Small Image
        System.Drawing.Image.GetThumbnailImageAbort myCallback = new System.Drawing.Image.GetThumbnailImageAbort(ThumbnailCallback);
        System.Drawing.Image myThumbnail = img.GetThumbnailImage(newWidth, newHeight, myCallback, IntPtr.Zero);
    
        //----------        Saving Image
        myThumbnail.Save(Server.MapPath("~/profile/NewImage.jpg"));
    }
    public bool ThumbnailCallback()
    {
        return false;
    }
