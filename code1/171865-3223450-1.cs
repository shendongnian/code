    using System.Data.SqlServerCe;
        protected void Page_Load(object sender, EventArgs e)
        {
            using (SqlCeConnection conn = new SqlCeConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["Northwind"].ConnectionString;
                conn.Open();
                using (SqlCeCommand cmd = new SqlCeCommand("SELECT TOP (1) [Category Name] FROM Categories", conn))
                {
                    string valueFromDb = (string)cmd.ExecuteScalar();
                    Response.Write(string.Format("{0} Time {1}", valueFromDb, DateTime.Now.ToLongTimeString()));
                }
            }
        }
