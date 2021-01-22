    static void Main(string[] args)
    {
        string connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Temp\SOTest3.xls;Extended Properties=""Excel 8.0;HDR=YES;""";
        DbProviderFactory factory =
          DbProviderFactories.GetFactory("System.Data.OleDb");
        using (DbConnection connection = factory.CreateConnection())
        {
            connection.ConnectionString = connectionString;
            using (DbCommand command = connection.CreateCommand())
            {
                connection.Open();  //open the connection 
                DateTime dtNew = Convert.ToDateTime("7/21/2010");
                DbDataAdapter da = factory.CreateDataAdapter();
                da.SelectCommand = command;
                da.SelectCommand.Connection = connection;
                da.SelectCommand.CommandText = "SELECT * FROM [Sheet1$] WHERE [Hand Off Date] = #" + dtNew.ToString("yyyy-MM-dd") + "#";
                DataTable dtDate = new DataTable();
                da.Fill(dtDate);
                Console.WriteLine(dtDate.Rows.Count);
                Console.ReadLine();                    
            }
        }
    }
