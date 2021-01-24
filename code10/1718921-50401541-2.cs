    string base64string = "";
    Bitmap bmpArea = null;
    //preparing our image
    using (MemoryStream m = new MemoryStream())
    {
        bmpArea.Save(m, ImageFormat.Jpeg);
        byte[] imageBytes = m.ToArray();
    
        base64string = Convert.ToBase64String(imageBytes);
    }
    //call request asynchronically
    Task.Run(async () => await Google_Vision_API_Request(base64string));
