    Microsoft.Office.Interop.Outlook.Inspector inspector = Globals.ThisAddIn.Application.ActiveInspector();
    Microsoft.Office.Interop.Outlook.MailItem item = inspector.CurrentItem as Microsoft.Office.Interop.Outlook.MailItem;
                    
    //Create dummy recipient object for UI bug
     Microsoft.Office.Interop.Outlook.Recipient dummy = 
     item.Recipients.Add("bugDummy");
     dummy.Type = (int)Microsoft.Office.Interop.Outlook.OlMailRecipientType.olBCC;
     //Create the BCC object that will be used
     Microsoft.Office.Interop.Outlook.Recipient mRecipient = item.Recipients.Add("test@user.de");
     mRecipient.Type = (int)Microsoft.Office.Interop.Outlook.OlMailRecipientType.olBCC;
    //iterate through the recipients and delete the dummy
    foreach (Microsoft.Office.Interop.Outlook.Recipient recipient in item.Recipients)
                    {
                        if (string.Compare(recipient.Name, "bugDummy", true) == 0)
                        {
                            recipient.Delete();
                            break;
                        }
                    }
