    internal Encoding QueryStringEncoding
    {
        get
        {
            Encoding contentEncoding = this.ContentEncoding;
            if (!contentEncoding.Equals(Encoding.Unicode))
            {
                return contentEncoding;
            }
            return Encoding.UTF8;
        }
    }
