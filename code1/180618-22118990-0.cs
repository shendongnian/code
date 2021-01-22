    public class HttpPostedFileStreamWrapper : HttpPostedFileBase
    {
        string _contentType;
        string _filename;
        Stream _inputStream;
        public HttpPostedFileStreamWrapper(Stream inputStream, string contentType = null, string filename = null)
        {
            _inputStream = inputStream;
            _contentType = contentType;
            _filename = filename;
        }
        public override int ContentLength { get { return (int)_inputStream.Length; } }
     
        public override string ContentType { get { return _contentType; } }
        /// <summary>
        ///  Summary:
        ///     Gets the fully qualified name of the file on the client.
        ///  Returns:
        ///      The name of the file on the client, which includes the directory path. 
        /// </summary>     
        public override string FileName { get { return _filename; } }
        public override Stream InputStream { get { return _inputStream; } }
        public override void SaveAs(string filename)
        {
            using (var stream = File.OpenWrite(filename))
            {
                InputStream.CopyTo(stream);
            }
        }
