     public void UserLogin(string Username, string Password)
     {
         ConsoleLog Log = new ConsoleLog();
         WebClient client = new WebClient();
         ServerURL = "http://play.projectzeternity.tk/logonapi.php?login&user=" + Username + "&password=" + Password; // Logon API
         string check = client.DownloadString(ServerURL);
         
         // validate the response here...
     }
