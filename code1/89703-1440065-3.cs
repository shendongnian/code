    public class MyBaseUriAnnotation
    {
        public XObject XObject { get; private set; }
        private string baseUri = String.Empty;
        public string BaseUri
        {
            get
            {
                if (String.IsNullOrEmpty(this.baseUri))
                    return this.XObject.BaseUri;
                return this.baseUri;
            }
            set { this.baseUri = value; }
        }
        public MyBaseUriAnnotation(XObject xobject)
           : this(xobject, String.Empty)
        {
        }
        public MyBaseUriAnnotation(XObject xobject, string baseUri)
        {
            if (xobject == null) throw new ArgumentNullException("xobject");
            this.XObject = xobject;
            this.baseUri = baseUri;
        }
    }
