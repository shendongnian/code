    static void CallProc()
    {
     //Establish connection
    MySqlConnection myConn = new MySqlConnection("user id=root;database=demobase;host=localhost");
    myConn.Open();
    //Set up myCommand to reference stored procedure 'myfunc'
    MySqlCommand myCommand = new MySqlCommand("myfunc", myConn);
    myCommand.CommandType = System.Data.CommandType.StoredProcedure;
    //Create input parameter and assign a value
    MySqlParameter myInParam = new MySqlParameter();
    myInParam.Value = "Mark";
    myCommand.Parameters.Add(myInParam);
    myInParam.Direction = System.Data.ParameterDirection.Input;
    //Create placeholder for return value
    MySqlParameter myRetParam = new MySqlParameter();
    myRetParam.Direction = System.Data.ParameterDirection.ReturnValue;
    myCommand.Parameters.Add(myRetParam);
    //Execute the function. ReturnValue parameter receives result of the stored function
    myCommand.ExecuteNonQuery();
    Console.WriteLine(myRetParam.Value.ToString());
    myConn.Close();
    }
