    using (FileStream fs = new FileStream( cacheFileName, FileMode.Open, FileAccess.Read )) 
    using (LumiSoft.Net.SMTP.Client.SMTP_Client client = 
       new LumiSoft.Net.SMTP.Client.SMTP_Client())
    {
    	client.SendMessage( fs );
    }
