        public String getUsername() {
        string username = null;
        try {
          ManagementScope ms = new ManagementScope("\\\\.\\root\\cimv2");
          ms.Connect();
          ObjectQuery query = new ObjectQuery
                  ("SELECT * FROM Win32_ComputerSystem");
          ManagementObjectSearcher searcher =
                  new ManagementObjectSearcher(ms, query);
          foreach (ManagementObject mo in searcher.Get()) {
            username = mo["UserName"].ToString();
          }
          string[] usernameParts = username.Split('\\');
          username = usernameParts[usernameParts.Length - 1];
        } catch (Exception) {
          username = "SYSTEM";
        }
        return username;
      }
    
