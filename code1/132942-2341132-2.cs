    public List<string> FindExistingValues()
    {
       List<string> results = new List<string>();
       string getStringsCmd = "SELECT (YourFieldName) FROM dbo.YourTableName";
       using(SqlConnection _con = new SqlConnection("your connection string here"))
       using(SqlCommand _cmd = new SqlCommand(getStringsCmd, _con)
       {
          _con.Open();      
          using(SqlDataReader rdr = _con.ExecuteReader())
          {
             while(rdr.Read())
             {
                 results.Add(rdr.GetString(0));
             }
             rdr.Close();
          }
          _con.Close();      
       }
       return results;
    }
