    try
    {
        if (bitmap.Width < Width && bitmap.Height < Height)
        {
            context.HttpContext.Response.ContentType = "image/gif";
            bitmap.Save(context.HttpContext.Response.OutputStream, ImageFormat.Jpeg);
            // insert bitmap.Dispose()  here
            return;
        }
    }
    catch (Exception e)
    {
        throw new Exception(e.Message);
    }
    finally
    {
        bitmap.Dispose();
    }
