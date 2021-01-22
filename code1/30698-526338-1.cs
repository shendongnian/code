To get at the bytes sent you can use the [HttpResponse.Filter][1] property. As the MSDN docs say this property gets or sets a wrapping filter object that is used to modify the HTTP entity body before transmission. 
You can create a new [System.IO.Stream][2] that wraps the existing HttpResponse.Filter stream and counts the bytes passed in to the Write method before passing them on. For example:
    public class ContentLengthModule : IHttpModule
    {
        public void Init(HttpApplication context)
        {
            context.BeginRequest += OnBeginRequest;
            context.EndRequest += OnEndRequest;
        }
        void OnBeginRequest(object sender, EventArgs e)
        {
            var application = (HttpApplication) sender;
            application.Response.Filter = new ContentLengthFilter(application.Response.Filter);
        }
        void OnEndRequest(object sender, EventArgs e)
        {
            var application = (HttpApplication) sender;
            var contentLengthFilter = (ContentLengthFilter) application.Response.Filter;
            var contentLength = contentLengthFilter.BytesWritten;
        }
        public void Dispose()
        {
        }
    }
    public class ContentLengthFilter : Stream
    {
        private readonly Stream _responseFilter;
        public int BytesWritten { get; set; }
        public ContentLengthFilter(Stream responseFilter)
        {
            _responseFilter = responseFilter;
        }
        public override void Flush()
        {
            _responseFilter.Flush();
        }
        public override long Seek(long offset, SeekOrigin origin)
        {
            return _responseFilter.Seek(offset, origin);
        }
        public override void SetLength(long value)
        {
            _responseFilter.SetLength(value);
        }
        public override int Read(byte[] buffer, int offset, int count)
        {
            return _responseFilter.Read(buffer, offset, count);
        }
        public override void Write(byte[] buffer, int offset, int count)
        {
            BytesWritten += count;
            _responseFilter.Write(buffer, offset, count);
        }
        public override bool CanRead
        {
            get { return _responseFilter.CanRead; }
        }
        public override bool CanSeek
        {
            get { return _responseFilter.CanSeek; }
        }
        public override bool CanWrite
        {
            get { return _responseFilter.CanWrite; }
        }
        public override long Length
        {
            get { return _responseFilter.Length; }
        }
        public override long Position
        {
            get { return _responseFilter.Position; }
            set { _responseFilter.Position = value; }
        }
    }
