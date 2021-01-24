    Microsoft.Office.Interop.Outlook.Application application = null;
    try
    {
    	application = new Microsoft.Office.Interop.Outlook.Application();
    	Microsoft.Office.Interop.Outlook.NameSpace nameSpace = application.GetNamespace("MAPI");fsdf
    
    	var startDate = DateTime.Now.AddDays(-7).ToString("dd/MM/yyyy HH:mm");
    	var endDate = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
    
    	var ns = application.GetNamespace("MAPI");
    	var inbox = ns.GetDefaultFolder(OlDefaultFolders.olFolderInbox);
    	var folder = inbox;
    	var filter = $"[sentOn] > '{startDate}' And [sentOn] < '{endDate}'";
    
    	var mailItems = folder.Items.Restrict(filter);
    
    	foreach (MailItem item in mailItems)
    	{
    		Console.WriteLine(item.Subject);
    	}
    	Console.ReadLine();
    }
    catch (System.Exception ex)
    {
    	throw;
    }
