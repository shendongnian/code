    public void ProcessRequest(HttpContext context)
    {
        byte[] imageBytes = File.ReadAllBytes(@"C:\Images" + context.Request["image"]);
        context.Response.ContentType = "image/jpeg";
        context.Response.BinaryWrite(imageBytes);
    }
