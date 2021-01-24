    private HttpPostedFileBase _file;
        [DataType(DataType.Upload)]
        public HttpPostedFileBase File
        {
            get { return _file; }
            set { _file = value; }
        }
