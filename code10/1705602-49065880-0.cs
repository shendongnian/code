    public ActionResult Barcode(string code)
    {
        var myBitmap = new Bitmap(500, 50);
        var g = Graphics.FromImage(myBitmap);
        // the code that makes the barcode
        // the code that makes the barcode
        // the code that makes the barcode
        // Put the image into a stream to return
        MemoryStream ms = new MemoryStream();
        myBitmap.Save(ms, ImageFormat.Png);
        // Reset the stream position before returning it
        ms.Position = 0;
        return new FileStreamResult(ms, "image/png");
    }
