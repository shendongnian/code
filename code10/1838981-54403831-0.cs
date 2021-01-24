    void Main()
    {
      string strCon =
          @"server=.\sqlexpress;database=Northwind;Trusted_connection=yes";
      DataTable schemaInfo;    
      string[] restrictions = {"Northwind",null,null,"BASE TABLE"};
          
      using( SqlConnection con = new SqlConnection(strCon))
      {
       con.Open();
       schemaInfo = con.GetSchema("Tables", restrictions );
       con.Close();
      }
      // schemaInfo datatable contains all tables
    }
