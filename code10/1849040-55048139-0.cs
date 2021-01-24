	public class MyContext : BaseDataContext {
		public MyContext()
				: this(GetDbConnection()) {
		}
		public MyContext(string connectionString)
				: base(connectionString) {
		}
		public static string GetDbConnection() {
			// Get the value from the AppSettings section in the Web.config file that will be updated by Key Vault
			var connectionString = ConfigurationManager.AppSettings["{key-vault-secret-name}"];
            // Return the connection string value above, if blank, use the connection string value expected in the Web.config
			return string.IsNullOrWhiteSpace(connectionString) ? "MyContext" : connectionString;
		}
	}
