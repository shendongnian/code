    SqlConnection cn = new SqlConnection();
    SqlCommand cmd = new SqlCommand();
    DataTable schemaTable; 
    SqlDataReader myReader; 
    			 
    //Open a connection to the SQL Server Northwind database.
    cn.ConnectionString = "Data Source=server;User ID=login;
                           Password=password;Initial Catalog=Northwind";
    cn.Open();
    
    //Retrieve records from the Employees table into a DataReader.
    cmd.Connection = cn;
    cmd.CommandText = "SELECT * FROM Employees";
    myReader = cmd.ExecuteReader(CommandBehavior.KeyInfo);
    
    //Retrieve column schema into a DataTable.
    schemaTable = myReader.GetSchemaTable();
    
    //For each field in the table...
    foreach (DataRow myField in schemaTable.Rows){
        //For each property of the field...
        foreach (DataColumn myProperty in schemaTable.Columns) {
    	//Display the field name and value.
    	Console.WriteLine(myProperty.ColumnName + " = " + myField[myProperty].ToString());
        }
        Console.WriteLine();
    
        //Pause.
        Console.ReadLine();
    }
    
    //Always close the DataReader and connection.
    myReader.Close();
    cn.Close();
