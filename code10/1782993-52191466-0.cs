    string sql = "";
    if (int.TryParse(ss.StoreNumber, out int n) == true)
    {
      sql = "SELECT * FROM SALES_STATUS WHERE store_no = :SerchStore";
    }
    else
    {
      sql = "SELECT * FROM SALES_STATUS;"
    }    
    //Creating cmd using sql and conn
    OracleCommand cmd = new OracleCommand(sql, conn);
    
    //Create Parameters to add value
    if (int.TryParse(ss.StoreNumber, out int n) == true)
    {
      cmd.Parameters.Add("SerchStore", int.Parse(ss.StoreNumber));
    }
  
