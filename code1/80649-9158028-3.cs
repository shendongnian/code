    try
     {
      ServerManager serverMgr = new ServerManager();
      string strWebsitename = txtwebsitename.Text; // abc
      string strApplicationPool = "DefaultAppPool";  // set your deafultpool :4.0 in IIS
      string strhostname = txthostname.Text; //abc.com
      string stripaddress = txtipaddress.Text;// ip address
      string bindinginfo = stripaddress + ":80:" + strhostname;
          
      //check if website name already exists in IIS
        Boolean bWebsite = IsWebsiteExists(strWebsitename);
        if (!bWebsite)
         {
            Site mySite = serverMgr.Sites.Add(strWebsitename.ToString(), "http", bindinginfo, "C:\\inetpub\\wwwroot\\yourWebsite");
            mySite.ApplicationDefaults.ApplicationPoolName = strApplicationPool;
            mySite.TraceFailedRequestsLogging.Enabled = true;
            mySite.TraceFailedRequestsLogging.Directory = "C:\\inetpub\\customfolder\\site";
            serverMgr.CommitChanges();
            lblmsg.Text = "New website  " + strWebsitename + " added sucessfully";
         }
         else
         {
            lblmsg.Text = "Name should be unique, " + strWebsitename + "  is already exists. ";
         }
       }
      catch (Exception ae)
      {
          Response.Redirect(ae.Message);
       }
