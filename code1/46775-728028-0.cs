    private static string DecipherUserName( string user )
    {           
       int start = user.IndexOf( "(" );
       if (start > -1)
       {
          return user.Substring( start ).Replace( "(", string.Empty ).Replace( ")", string.Empty );
       }
       else
       {
          return user;
       }
    }
