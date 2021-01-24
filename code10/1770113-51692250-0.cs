      protected void getSUM()
    {
    // SQL query that gets total of product sales where category id = 1
    string SqlQuery = @"SELECT SUM(ProductSales) AS TotalSales 
      FROM [NORTHWIND].[dbo].[Sales by Category] 
      WHERE CategoryID = 1";
  
    // Declare and open a connection to database
    SqlConnection conn = new SqlConnection(
    ConfigurationManager.ConnectionStrings["NorthwindConnStr"].ConnectionString);
    conn.Open();
  
    // Creates SqlCommand object
    SqlCommand comm = new SqlCommand(SqlQuery, conn);
  
    // Gets total sales
    decimal TotalSales = Convert.ToDecimal(comm.ExecuteScalar());
  
    // Close connection
    conn.Close();
    conn.Dispose();
    comm.Dispose();
    // Adds formatted output to GridView footer
    GridView1.Columns[1].FooterText = String.Format("{0:c}", TotalSales);
    }
