    public class FilteredProxy : IWebProxy
    {
        readonly IWebProxy _wrapped;
        readonly Regex _useFor;
        public FilteredProxy(IWebProxy wrapped, Regex useFor)
        {
            _wrapped = wrapped;
            _useFor = useFor;
        }
        public bool IsBypassed(Uri host)
        {
            return !_useFor.IsMatch(host.ToString()) || _wrapped.IsBypassed(host);
        }
        public Uri GetProxy(Uri destination) => _wrapped.GetProxy(destination);
        public ICredentials Credentials
        {
            get => _wrapped.Credentials;
            set => _wrapped.Credentials = value;
        }
    }
