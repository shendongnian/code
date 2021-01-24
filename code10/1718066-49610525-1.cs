    Using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Data.OracleClient;
    using System.Data;
    
    namespace CallingOracleStoredProc
    {
        class Program
        {
            static void Main(string[] args)
            {
                using (OracleConnection objConn = new OracleConnection("Data Source=*your datasource*; User ID=*Your UserID*; Password=*Your Password*"))
                {
                    OracleCommand objCmd = new OracleCommand();
                    objCmd.Connection = objConn;
                    objCmd.CommandText = "Get_Added_Request_ID";
                    objCmd.CommandType = CommandType.StoredProcedure;
                    objCmd.Parameters.Add("ATTR_", OracleType.NVarChar).Value = "test";
                    objCmd.Parameters.Add("REQUEST_ID", OracleType.NVarChar).Direction = ParameterDirection.Output;
    
                    try
                    {
                        objConn.Open();
                        objCmd.ExecuteNonQuery();
                        System.Console.WriteLine("The Request ID is {0}", objCmd.Parameters["REQUEST_ID"].Value);
                    }
                    catch (Exception ex)
                    {
                        System.Console.WriteLine("Exception: {0}",ex.ToString());
                    }
     
                    objConn.Close();
    
                }
            }
        }
    
    }
