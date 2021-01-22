    class Mail
    {
        private string uri;
        private string from;
        private string body;
        public string Uri
        {
            get { return this.uri; }
            set { this.uri = value; }
        }
        public string From
        {
            get { return this.from; }
            set { this.from = value; }
        }
        public string Body
        {
            get { return this.body; }
            set { this.body = value; }
        }
    }
