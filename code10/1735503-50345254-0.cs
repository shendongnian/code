    string targetSiteURL = @"https://xx.sharepoint.com/sites/lz";
    
    var login = "lz@xxx.onmicrosoft.com";
    var password = "xxx";
    
    var securePassword = new SecureString();
    
    foreach (char c in password)
    {
    	securePassword.AppendChar(c);
    }
    SharePointOnlineCredentials onlineCredentials = new SharePointOnlineCredentials(login, securePassword);
    
    ClientContext ctx = new ClientContext(targetSiteURL);
    ctx.Credentials = onlineCredentials;
    var web = ctx.Web;
    ctx.Load(web);
    ctx.ExecuteQuery();
    
    var filePath = web.ServerRelativeUrl + "/Shared%20Documents/09.%20SharePoint%20Tutorials/SharePoint%20365%20Co-authoring%20excel%20files.docx";
    FileInformation fileInformation = Microsoft.SharePoint.Client.File.OpenBinaryDirect(ctx, filePath);
    
    using (System.IO.StreamReader sr = new System.IO.StreamReader(fileInformation.Stream))
    {
    	String line = sr.ReadToEnd();
    	Console.WriteLine(line);
    }
    Console.ReadKey();
