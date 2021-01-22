    Using System.Data.SqlClient;
    
    //////now use following codes to retrieve data//////
    String ConStr = "Data Source=localhost;Initial Catalog=Database Name;Integrated Security=True";
            SqlConnection sqlcnn;
            SqlCommand sqlcmd;
            SqlDataReader sqldr;
            string plssql;
    plssql = "select field from table_name where condition";
            sqlcnn = new SqlConnection(ConStr);
            sqlcnn.Open();
            sqlcmd = new SqlCommand(plssql, sqlcnn);
            sqldr = sqlcmd.ExecuteReader();
    String val=sqldr["field name"].ToString();
    sqlcmd.Close();
    sqlcnn.Close();
