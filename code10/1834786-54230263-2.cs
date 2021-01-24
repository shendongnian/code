    public class MyDatabaseConnection
    {
    
    string connectionString = "Data Source= my DS3;Initial Catalog = MyCATA;Persist Security Info=True;User ID=sa;Password=mypsw*";
    public MyDatabaseConnection(string connectionString)
    {
        this.connectionString = connectionString;
        // create a database connection perhaps
    }
        // some methods for querying a database
     public bool execute(string query)
        {
            SqlConnection sqlCon = new SqlConnection(connectionString);
            try
            {
                sqlCon.Open();
                SqlDataAdapter sqlDaMonitor = new SqlDataAdapter("select * from TLogging where BatchNumber like '%" + query + "%' ", sqlCon);
                DataTable dtblMonitor = new DataTable();
                sqlDaMonitor.Fill(dtblMonitor);
                if ((dtblMonitor == null) || (dtblMonitor.Rows.Count == 0)) {
                    MessageBox.Show("SEARCH OTHER DATABASE");
                    myCon.Val += 1;
                    MessageBox.Show(myCon.MyDTConn);
                    return false;
                }
            }
            catch(Exception ex)
            {
                return false;
            }
            return true;
        }
    
    }
