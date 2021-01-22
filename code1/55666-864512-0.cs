    static void Main()
            {
    
                 DirectorySearcher ds = new DirectorySearcher("");
                 ds.Filter = "objectCategory=computer";
                 SearchResultCollection results = ds.FindAll();
                 foreach (SearchResult result in results)
                 {
                     string pattern = @"(?<=LDAP://CN=)(?<serverName>\w*)(?=,*)";
                     Match m = Regex.Match(result.Path, pattern);
                     string serverName = m.Groups["serverName"].Value;
    
                     System.Net.Sockets.TcpClient tcp = new System.Net.Sockets.TcpClient();
                     try
                     {
                         tcp.Connect(serverName, 25);
                     
                         if (tcp.Connected)
                         {
                             Console.WriteLine(String.Format("Connected to {0} on Port 25", serverName));
                         }
                     }
    
                     catch (Exception ex)
                     {
                         Console.WriteLine("Exception: " + ex.Message);
                     }
    
                     finally
                     {
                         tcp.Close();
                     }
                    
                 }
    
                 Console.WriteLine("Done.");
                 Console.ReadLine();
    }
