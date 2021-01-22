    // you pass in a UserID (numeric), you get back a list of roles that user has
    public List<string> GetRolesForUser(int userID)
    {    
       // SQL select statement - adjust as needed 
       string selectStmt = "SELECT Role FROM dbo.UserRole WHERE UserID = @YourUserID";
       // create the resulting list of roles
       List<string> _allRoles = new List<string>();
       // define SqlConnection and SqlCommand to grab the data
       using(SqlConnection _con = new SqlConnection('your connection string here'))
       using(SqlCommand _cmd = new SqlCommand(selectStmt, _con))
       {
           // define the parameter for your SQL statement and fill the value
           _cmd.Parameters.Add("@YourUserID", SqlDbType.Int);
           _cmd.Parameters["@YourUserID"].Value = userID;
           _con.Open();
           // create SqlDataReader to grab the rows
           using(SqlDataReader rdr = _cmd.ExecuteReader())
           {
               // loop over all rows returned by SqlDataReader
               while(rdr.Read())
               {
                  // grab the column no. 0 (corresponds to "Role" from your
                  // SQL select statement) as a string, and store it into list of roles
                  _allRoles.Add(rdr.GetString(0));
               }
           }
       }    
       return _allRoles;
    }
