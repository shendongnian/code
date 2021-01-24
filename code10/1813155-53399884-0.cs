    //comments should focus on "why", rather than "what"
    public static Boolean ValidateUser(string struser, string strpass)
    {
        using (var conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["conn string name"].ConnectionString))
        using (var sql_comm = new SqlCommand(""SELECT count(userID) FROM HIEPA.HIEPA_USERS where UserName = @usuario and UserPassword = @contrasena ; ", conn))
        {
            //Don't use AddWithValue(). It forces ADO.Net to guess about parameter types.
            //Use exact column types and lengths instead
            sql_comm.Parameters.Add("@usuario", SqlDbType.NVarChar, 50).Value = struser;
            //Dear God, please tell me you're not using a plain-text password? That's a HUGE mistake!
            sql_comm.Parameters.Add("@contrasena", SqlDbType.NVarChar, 180).Value = strpass;
    
            conn.Open();
            return (1 == (int)sql_comm.ExecuteScalar());
        }
    }
