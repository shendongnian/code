    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Windows.Forms;
    
    namespace WindowsFormsApp1
    {
        public partial class Form1 : Form
        {
    
            static string connectionString = @"Data Source=.;Initial Catalog=YourDatabase;Integrated Security=SSPI";
    
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
                    SqlParameter[] para = new SqlParameter[6];
                    para[0] = new SqlParameter("@user_name", "test");
                    para[1] = new SqlParameter("@action_type_id", System.DBNull.Value);
                    para[2] = new SqlParameter("@document_type_id", System.DBNull.Value);
                    para[3] = new SqlParameter("@date_from", DateTime.Parse("2018-04-15"));
                    para[4] = new SqlParameter("@date_to", DateTime.Parse("2018-04-16"));
                    para[5] = new SqlParameter("@seen", 1);
                    cmd.Parameters.AddRange(para);
                    var depenedency = new SqlDependency(cmd);
    
                    depenedency.OnChange += new OnChangeEventHandler(sqlDependency_OnChange);
                    dt.Rows.Clear();
                    dt.Load(cmd.ExecuteReader(CommandBehavior.CloseConnection));
                }
            }
    
            private void sqlDependency_OnChange(object sender, SqlNotificationEventArgs e)
            {
                MessageBox.Show($"OnChange Event fired. SqlNotificationEventArgs: Info={e.Info}, Source={e.Source}, Type={e.Type}\r\n");
    
                //resubscribe only if valid
                if ((e.Info != SqlNotificationInfo.Invalid)
                    && (e.Type != SqlNotificationType.Subscribe))
                {
                    SearchUserLog();
                }
            }
        }
    }
