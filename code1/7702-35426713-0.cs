               string login = "";
               string domain = "";
               string password = "";
      
               using (UserImpersonation user = new UserImpersonation(login, domain, password))
               {
                   if (user.ImpersonateValidUser())
                   {
                       File.WriteAllText("test.txt", "your text");
                       Console.WriteLine("File writed");
                   }
                   else
                   {
                       Console.WriteLine("User not connected");
                   }
               }
