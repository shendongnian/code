    public class UrlBuilder
    {
        #region Variables / Properties
        private readonly StringBuilder _builder;
        #endregion Variables / Properties
        #region Constructor
        public UrlBuilder(string urlBase)
        {
            _builder = new StringBuilder(urlBase);
        }
        #endregion Constructor
        #region Methods
        public UrlBuilder AppendParameter(string paramName, string value)
        {
            if (_builder.ToString().Contains("?"))
                _builder.Append("&");
            else
                _builder.Append("?");
            _builder.Append(HttpUtility.UrlEncode(paramName));
            _builder.Append("=");
            _builder.Append(HttpUtility.UrlEncode(value));
            return this;
        }
        public override string ToString()
        {
            return _builder.ToString();
        }
        #endregion Methods
    }
