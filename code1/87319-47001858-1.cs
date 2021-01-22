    public void Test(Image img)
    {
        ImageCodecInfo info = img.GetCodecInfo();
        if (info == null)
            Trace.TraceError("Image format is unkown");
        else
            Trace.TraceInformation("Image format is " + info.FormatDescription);
    }
