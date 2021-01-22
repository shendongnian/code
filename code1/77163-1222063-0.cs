     Regex expression = new Regex(@"^\w*");
     var passwd = new StreamReader( "/etc/passwd" );
     var users = new List<string>();
     while (passwd.Peek() >= 0)
     {
         var line = passwd.ReadLine();
         foreach (Match myMatch in expression.Matches(txt))
         {
             users.Add( myMatch.ToString() );
         }
     }
     // now users will contain all the users in the file
