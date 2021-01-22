    using Outlook;
    
     Outlook.Application oOutlook;
     Outlook.NameSpace oNs;
     Outlook.MAPIFolder oFldr;
     long iAttachCnt;
    
     try
     {
         oOutlook = new Outlook.Application();
         oNs = oOutlook.GetNamespace(”MAPI”);
    
         //getting mail folder from inbox
         oFldr = oNs.GetDefaultFolder(OlDefaultFolders.olFolderInbox);
         Response.Write(”Total Mail(s) in Inbox :” + oFldr.Items.Count + “<br>”);
         Response.Write(”Total Unread items = ” + oFldr.UnReadItemCount);
         foreach (Outlook.MailItem oMessage in oFldr.Items)
         {
             StringBuilder str = new StringBuilder();
             str.Append(”<table style=’border:1px solid gray;font-family:Arial;font-size:x-small;width:80%;’ align=’center’><tr><td style=’width:20%;’><b>Sender :</b></td><td>”);
             str.Append(oMessage.SenderEmailAddress.ToString() + “</td></tr>”);
             //basic info about message
             str.Append(”<tr><td><b>Date :</b></td><td>” + oMessage.SentOn.ToShortDateString() + “</td></tr>”);
             if (oMessage.Subject != null)
             {
                 str.Append(”<tr><td><b>Subject :</b></td><td>” + oMessage.Subject.ToString() + “</td></tr>”);
             }
             //reference and save all attachments
    
             iAttachCnt = oMessage.Attachments.Count;
             if (iAttachCnt > 0)
             {
                 for (int i = 1; i <= iAttachCnt; i++)
                 {
                     str.Append(”<tr><td><b>Attachment(” + i.ToString() + “) :</b></td><td>” + oMessage.Attachments[i].FileName + “</td></tr>”);
                 }
             }
             str.Append(”</table><br>”);
             Response.Write(str.ToString());
    
         }
    
     }
     catch (System.Exception ex)
     {
         Response.Write(”Execption generated:” + ex.Message);
     }
     finally
     {
         GC.Collect();
         oFldr = null;
         oNs = null;
         oOutlook = null;
    
     }
