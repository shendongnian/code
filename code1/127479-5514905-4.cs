    public Uri Url
    {
        get
        {
            if ((this._url == null) && (this._wr != null))
            {
                string queryStringText = this.QueryStringText;
                if (!string.IsNullOrEmpty(queryStringText))
                {
                    queryStringText = "?" + HttpEncoder.CollapsePercentUFromStringInternal(queryStringText, this.QueryStringEncoding);
                }
                if (AppSettings.UseHostHeaderForRequestUrl)
                {
                    string knownRequestHeader = this._wr.GetKnownRequestHeader(0x1c);
                    try
                    {
                        if (!string.IsNullOrEmpty(knownRequestHeader))
                        {
                            this._url = new Uri(this._wr.GetProtocol() + "://" + knownRequestHeader + this.Path + queryStringText);
                        }
                    }
                    catch (UriFormatException)
                    {
                    }
                }
                if (this._url == null)
                {
                    string serverName = this._wr.GetServerName();
                    if ((serverName.IndexOf(':') >= 0) && (serverName[0] != '['))
                    {
                        serverName = "[" + serverName + "]";
                    }
                    this._url = new Uri(this._wr.GetProtocol() + "://" + serverName + ":" + this._wr.GetLocalPortAsString() + this.Path + queryStringText);
                }
            }
            return this._url;
        }
    }
