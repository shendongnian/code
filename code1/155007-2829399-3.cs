    public static class ApplicationFacade {
        private static readonly ApplicationFactory _applicationFactory = new ApplicationFactory();
        public static DefaultConnectionString {
            get {
                return Properties.Settings.Default.DefaultConnectionString;
            }
        }
        public static IList<ICustomer> GetCustomers() {
            using(var connection = OpenConnection())
               _applicationFactory.GetCustomers(connection);
        }
        public MySqlConnection OpenConnection() {
            var newConnection = new MySqlConnection(DefaultConnectionString);
            try {
                newConnection.Open();
            } catch (Exception ex) {
                // Exception handling...
            }
            return newConnection;
        }
    }
    internal sealed class ApplicationFactory {
        internal ApplicationFactory() {
        }
        internal IList<ICustomer> GetCustomers(MySqlConnection connection) {
            if (connection.State != ConnectionState.Open)
                throw new InvalidOperationException()
            IList<ICustomer> customers = new List<ICustomer>();
            var command = new MySqlCommand(connection, @"select * from Customers");
            // Place code to get customers here...
            return customers;
        }
    }
    // So you'll be able to use share the same connection throught your factory whenever needed, preventing the overkill of authentication over and over again. Here's how this would be used:
    public partial class MainForm : Form {
        private void PopulateGrid() {
            dataGridView1.DataSource = ApplicationFacade.GetCustomers();
            // And you never care about the connection! All you want is the list of customers, that's all!
        }
    }
