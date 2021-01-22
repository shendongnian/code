    public static string GetConnectionString(string strConnection)
    {
     //Declare a string to hold the connection string
     string sReturn = new string("");
     //Check to see if they provided a connection string name
     if (!string.IsNullOrEmpty(strConnection))
     {
      //Retrieve the connection string fromt he app.config
      sReturn = ConfigurationManager.ConnectionStrings(strConnection).ConnectionString;
     }
     else
     {
      //Since they didnt provide the name of the connection string
      //just grab the default on from app.config
      sReturn = ConfigurationManager.ConnectionStrings("YourConnectionString").ConnectionString;
     }
     //Return the connection string to the calling method
     return sReturn;
    }
