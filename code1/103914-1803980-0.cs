    private string _cookieAsString = string.Empty;
        
        protected string CookieAsString
        {
            get { return _cookieAsString; }
            set
            {
                if (value != null)
                {
                    if (!_cookieAsString.Contains(value))
                    {
                        if (_cookieAsString.Length == 0)
                            _cookieAsString = value;
                        else
                            _cookieAsString += string.Format(";{0}", value);
                    }
                }
            }
        }
