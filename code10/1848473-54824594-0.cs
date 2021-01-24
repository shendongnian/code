    public class HttpPostedFileBaseDerived : HttpPostedFileBase
    {
        public HttpPostedFileBaseDerived(int contentLength, string contentType, string fileName, Stream inputStream)
        {
            ContentLength = contentLength;
            ContentType = contentType;
            FileName = fileName;
            InputStream = inputStream;
        }
        public override int ContentLength { get; }
        public override string ContentType { get; }
        public override string FileName { get; }
        public override Stream InputStream { get; }
        public override void SaveAs(string filename) { }
    }
}
Since `constructor is not affected by ReadOnly`, you can easily `copy in the values from your original file` object `to` your `derived class's instance`, while putting your new name in as well:
HttpPostedFileBase renameFile(HttpPostedFileBase file, string newFileName)
{
    string ext = Path.GetExtension(file.FileName); //don't forget the extension
    HttpPostedFileBaseDerived test = new HttpPostedFileBaseDerived(file.ContentLength, file.ContentType, (newFileName + ext), file.InputStream);
    return (HttpPostedFileBase)test; //cast it back to HttpPostedFileBase 
}
Once you are done you can `type cast` it back to `HttpPostedFileBase` so you wouldn't have to change any other code that you already have.
Hope this helps to anyone in the future. Also thanks to Manoj Choudhari for his answer, thanks to I learned of where not to look for the solution.
