    using (var con = new SqlConnection("server=.;database=tempdb;integrated security=true"))
    {
       con.Open();
       SqlCommand cmd = con.CreateCommand();
       cmd.CommandText = "sp_UpdateSearchValues";
       cmd.CommandType = System.Data.CommandType.StoredProcedure;
       var pAuthID = cmd.Parameters.Add("@pAuthID", SqlDbType.NVarChar,255 );
       var pgKey = cmd.Parameters.Add("@pgKey", SqlDbType.Int);
       var pSearch01 = cmd.Parameters.Add("@pSearch01", SqlDbType.NVarChar, 255);
       pAuthID.Value = "a";
       pgKey.Value = 1;
       pSearch01.Value = DBNull.Value;
       var r = cmd.ExecuteScalar();
       Console.WriteLine($"{r} {r.GetType().Name}");
       Console.ReadKey();
    }
