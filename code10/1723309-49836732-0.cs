    CREATE TABLE dbo.UserLog(
    	col1 int
    )
    GO
    CREATE PROC dbo.ManageUserLog
    AS
    SELECT col1 FROM dbo.UserLog;
    GO
    GRANT EXEC ON dbo.ManageUserLog TO public;
    GO
    using System.Data;
    using System.Data.SqlClient;
    using System.Windows.Forms;
    
    namespace WindowsFormsApp1
    {
        public partial class Form1 : Form
        {
    
            static string connectionString = @"Data Source=YourServer;Initial Catalog=YourDatabase;Integrated Security=SSPI";
    
            public Form1()
            {
                InitializeComponent();
                SqlDependency.Start(connectionString);
                SearchUserLog();
            }
    
            public void SearchUserLog()
            {
                DataTable dt = new DataTable();
                using (SqlConnection con = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand())
                {
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "dbo.ManageUserLog";
                    var depenedency = new SqlDependency(cmd);
    
                    depenedency.OnChange += new OnChangeEventHandler(sqlDependency_OnChange);
                    dt.Rows.Clear();
                    dt.Load(cmd.ExecuteReader(CommandBehavior.CloseConnection));
                }
    
            }
    
            private void sqlDependency_OnChange(object sender, SqlNotificationEventArgs e)
            {
                MessageBox.Show($"OnChange Event fired. SqlNotificationEventArgs: Info={e.Info}, Source={e.Source}, Type={e.Type}");
                SearchUserLog();
            }
        }
    }
