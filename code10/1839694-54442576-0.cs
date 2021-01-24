    public  void SaveLog( T Obj, string Operation)
        {
      
            string hostName = Dns.GetHostName(); // Retrive the Name of HOST  IpAddress
            string myIP = Dns.GetHostEntry(hostName).AddressList[0].ToString();
    
            var user = HttpContext.Current.Session["user"] as View_Emps;
