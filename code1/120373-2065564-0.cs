    using System;
    using System.Data;
    using Oracle.DataAccess.Client;
    class SomeClass
    {
        void SomeMethod(string connectionString, int[] anArrayOfKeys)
        {
            using (var con = new OracleConnection(connectionString))
            using (var cmd = con.CreateCommand())
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "StoredProcedureNameGoesHere";
                cmd.Parameters.Add(
                    "ParameterNameGoesHere",
                    OracleDbType.Array,
                    anArrayOfKeys,
                    ParameterDirection.Input);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
