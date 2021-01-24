    using System.Collections.Generic;
    using System.Linq;
    using Outlook = Microsoft.Office.Interop.Outlook;
    using System.Diagnostics;
    using System.Runtime.InteropServices;
    
    namespace oMailBoard
    {
    	public static class GetMail
    	{
    		public static void SearchOutLook()
    		{
    			Outlook.Application application = null;
    			Outlook.NameSpace nameSpace = null;
    			Outlook.MAPIFolder inbox = null;
    			Outlook.Items mailItems = null;
    			IEnumerable<Outlook.MailItem> emails = null;
    			string filter = "";
    			filter = $"[Categories] = 'Important'"; //Exact match
    			filter = $"@SQL=urn:schemas:httpmail:subject like '%database%'"; //Like match
    
    			if (Process.GetProcessesByName("Outlook").Count() > 0) //Is Outlook Open?
    			{
    				application = Marshal.GetActiveObject("Outlook.Application") as Outlook.Application;
    				nameSpace = application.GetNamespace("mapi");
    				inbox = nameSpace.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderInbox);
    				mailItems = inbox.Items;
    
    				//Store results into a numerable varible.
    				emails = mailItems.Restrict(filter).Cast<Outlook.MailItem>(); 
    
    				//Now I can iterate though the results. 
    				foreach (Outlook.MailItem e in emails)
    				{
    					Debug.WriteLine("\f");					
    					Debug.WriteLine(e.Subject);
    					
    				}
    
    				Debug.WriteLine(emails.Count());
    
    				inbox = null;
    				nameSpace = null;
    				application = null;
    			}
    			else
    			{
    				Debug.WriteLine("Outlook Not Open!");
    			}
    
    		}
    
    
    	}
    }
