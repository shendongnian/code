    [WebMethod]
    public void Save(byte[] bytes)
    {
        //if for any reason you need to convert it back to image
        var image = (Bitmap)(new ImageConverter().ConvertFrom(bytes));
    }
