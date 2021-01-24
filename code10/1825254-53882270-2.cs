       // static: we don't want form's instance: "this"
       private static bool IsCredentialValid(string login, string password) {
         //TODO: do not hardcode the connection string, but load it 
         // new SqlConnection() - do not cache conections, but create them
         // using - do not forget to free resources
         using (SqlConnection con = new SqlConnection(@"...")) {
           // Make Sql readable and parametrized
           string sql = 
             @"select 1 -- we don't want to fetch any data
                 from db
                where [UserName] = @UserName and
                      [Password] = @Password";
           using (SqlCommand q = new SqlCommand(sql, con)) {
             //TODO: better to specify params' types via Parameters.Add(...)
             q.Parameters.AddWithValue("@UserName", login); 
             q.Parameters.AddWithValue("@Password", password);  
             using (SqlDataReader reader = q.ExecuteReader()) {
               // Credential is valid if we have at least one record read
               return reader.Read();
             } 
           } 
         }
       }
