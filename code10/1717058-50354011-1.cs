    using Oracle.ManagedDataAccess.Client;
    using Oracle.ManagedDataAccess.Types;
    using System;
    using System.Configuration;
    //I'm not including the namespace, class or function declaration, but the following should be inside your fuction
    // myconnection is the your oracle connection string as defined in your config (web.config or app.config)
    using (OracleConnection cnx = new OracleConnection(ConfigurationManager.ConnectionStrings["myconnection"].ConnectionString))
    {
       cnx.Open();
       // You prepare the statement here
       OracleCommand commProc = new OracleCommand();
       commProc.Connection = cnx;
       commProc.CommandText = @"MYPROCEDURE.MYPROCEDURE";
       commProc.CommandType = System.Data.CommandType.StoredProcedure;
       // Here you add all the parameters (in and out) for the procedure
       commProc.Parameters.Add(new OracleParameter("p_param1", OracleDbType.Varchar2)
       {
           Value = v_param1, //This would be the C# variable or value you're putting in
           Size = 9 //This has to be the expected maximum size for a string value in your PL/SQL code.
        });
        commProc.Parameters.Add(new OracleParameter("p_param2", OracleDbType.Decimal)
       {
            Value = v_param2, //This would be the C# variable or value you're putting in
        });
       commProc.Parameters.Add(new OracleParameter("p_output1", OracleDbType.Varchar2)
       {
           Direction = System.Data.ParameterDirection.Output, //For output params, you don't specify values, but you have to specify direction.
           Size = 500 //This has to be the expected maximum size for the string value in your PL/SQL code.
        });
        commProc.Parameters.Add(new OracleParameter("p_output2", OracleDbType.Decimal)
       {
            Direction = System.Data.ParameterDirection.Output, //For output params, you don't specify values, but you have to specify direction.
        });
       // Here you actually execute the procedure.
       commProc.ExecuteNonQuery();
       
       // Once the procedure is exectued, you can access the values for the output params using the commProc.Parameters list.
       string v_output1 = commProc.Parameters["p_output1"]?.Value?.ToString();
       decimal v_output2 = (decimal) commProc.Parameters["p_output2"]?.Value;
       // You prepare the statement here
       OracleCommand commFunc = new OracleCommand();
       commFunc.Connection = cnx;
       commFunc.CommandText = @"MYPROCEDURE.MYFUNCTION";
       commFunc.CommandType = System.Data.CommandType.StoredProcedure;
       // Here you add all the parameters (in and out) for the procedure
       // When calling functions, the first parameter must be the return value expected from the function. Here you can name it as you wish. I usually name them return_value
       commFunc.Parameters.Add(new OracleParameter("return_value", OracleDbType.Varchar2)
       {
           Direction = System.Data.ParameterDirection.ReturnValue, //For return params, you don't specify values, but you have to specify direction.
           Size = 500 //This has to be the expected maximum size for a string value in your PL/SQL code.
        });
       commFunc.Parameters.Add(new OracleParameter("p_param1", OracleDbType.Varchar2)
       {
           Value = v_param1, //This would be the C# variable or value you're putting in
           Size = 9 //This has to be the expected maximum size for a string value in your PL/SQL code.
        });
        commFunc.Parameters.Add(new OracleParameter("p_output1", OracleDbType.Decimal)
       {
            Direction = System.Data.ParameterDirection.Output, //For output params, you don't specify values, but you have to specify direction.
        });
       // Here you actually execute the procedure.
       commFunc.ExecuteNonQuery();
       
       // Once the procedure is exectued, you can access the values for the output params using the commFunc.Parameters list.
       string v_return = commProc.Parameters["return_value"]?.Value?.ToString();
       decimal v_output1 = (decimal) commFunc.Parameters["p_output1"]?.Value;
    }
