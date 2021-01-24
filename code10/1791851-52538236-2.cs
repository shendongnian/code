    public class UsernameParameter : ResolvedParameter<string>
    {
        public static UsernameParameter Instance => new UsernameParameter();
        public static string ParameterName => "userName";
        private UsernameParameter() : base(ParameterName)
        {
        }
    }
    public class ConnectionStringParameter : ResolvedParameter<string>
    {
        public static ConnectionStringParameter Instance => new ConnectionStringParameter();
        public static string ParameterName => "connectionString";
        private ConnectionStringParameter() : base(ParameterName)
        {
        }
    }
