    public class CustomSQLMembershipProvider : SqlMembershipProvider {
      private readonly string _server;
      private readonly string _port;
    
      /// <summary>
      /// Initializes a new instance of the <see cref="T:System.Web.Security.SqlMembershipProvider"/> class.
      /// </summary>
      public CustomSQLMembershipProvider() {
        string[] args = System.Environment.GetCommandLineArgs();
        // args[0] is the exe name
        _server = args[1];
        _port = args[2];
      }
    
      public override void Initialize(string name, System.Collections.Specialized.NameValueCollection config)
      {
        base.Initialize(name, config);
    
        // Update the private connection string field in the base class.
        string connectionString = string.Format(@"Data Source={0},{1};Initial Catalog=aspnetdb;UID=NICCAMembership;PWD=_Password1;Application Name=NICCA;Connect Timeout=120;", _server, _port);
    
        // Set private property of Membership provider.
        FieldInfo connectionStringField = GetType().BaseType.GetField("_sqlConnectionString", BindingFlags.Instance | BindingFlags.NonPublic);
        connectionStringField.SetValue(this, connectionString);
      }
    }
