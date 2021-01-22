<pre>
private void Page_Load(object sender, EventArgs e)
{
    WriteQueryStringInformationToDB(Request.QueryString);
    Image image = LoadYourImageHere();
    using (MemoryStream stream = new MemoryStream())
    {
        base.Response.Clear();
        base.Response.ContentType = "image/png";
        image.Save(stream, ImageFormat.Png);
        stream.WriteTo(base.Response.OutputStream);
        base.Response.End();
    }
}
</pre>
