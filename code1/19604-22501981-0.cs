    using Outlook = Microsoft.Office.Interop.Outlook;
    
    // Create the Outlook application.
    Outlook.Application oApp = null;
    
    // Check whether there is an Outlook process running.
    int outlookRunning = Process.GetProcessesByName("OUTLOOK").Length;
    if (outlookRunning > 0)
    {
        // If so, use the GetActiveObject method to obtain the process and cast it to an Application object.
        try
        {
            oApp = Marshal.GetActiveObject("Outlook.Application") as Outlook.Application;
        }
        catch (Exception)
        {
            oApp = Activator.CreateInstance(Type.GetTypeFromProgID("Outlook.Application")) as Outlook.Application;
        }
        finally
        {
            // At this point we must kill Outlook (since outlook was started by user on a higher prio level than this current application)
            // kill Outlook (otherwise it will only work if UAC is disabled)
            // this is really a kind of last resort
            Process[] workers = Process.GetProcessesByName("OUTLOOk");
            foreach (Process worker in workers)
            {
                worker.Kill();
                worker.WaitForExit();
                worker.Dispose();
            }
        }
    }
    else
    {
        // If not, create a new instance of Outlook and log on to the default profile.
        oApp = new Outlook.Application();
        Outlook.NameSpace nameSpace = oApp.GetNamespace("MAPI");
        try
        {
            // use default profile and DO NOT pop up a window
            // on some pc bill gates fails to login without the popup, then we must pop up and lets use choose profile and allow access
            nameSpace.Logon("", "", false, Missing.Value);
        }
        catch (Exception)
        {
            // use default profile and DO pop up a window
            nameSpace.Logon("", "", true, true);
        }
        nameSpace = null;
    }
    
    // Done, now you can do what ever you want with the oApp, like creating a message and send it
    // Create a new mail item.
    Outlook.MailItem oMsg = (Outlook.MailItem)oApp.CreateItem(Outlook.OlItemType.olMailItem);
