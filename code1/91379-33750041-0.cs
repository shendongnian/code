    public class FilteringMySqlErrorLog : MySqlErrorLog
    {
        static readonly string[] _stripSearch = new[] { "password", "cardnumber", "ccnumber", "cvv" };
        public FilteringMySqlErrorLog(IDictionary config)
            : base(config)
        { }
        public override string Log(Error error)
        {
            error.ServerVariables.Remove("AUTH_PASSWORD");
            foreach (string key in error.Form.AllKeys.ToList())
            {
                if (_stripSearch.Any(x => key.IndexOf(x, StringComparison.InvariantCultureIgnoreCase) != -1))
                    error.Form.Remove(key);
            }
            return base.Log(error);
        }
    }
