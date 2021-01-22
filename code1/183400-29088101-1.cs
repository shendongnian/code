         using Outlook = Microsoft.Office.Interop.Outlook;
         private void sendEmail(string DistributionList, string AttachmentDestination)
          {
            //new outlook instance
            Microsoft.Office.Interop.Outlook.Application app =
                new Microsoft.Office.Interop.Outlook.Application();
            
            //new mail object
            Microsoft.Office.Interop.Outlook.MailItem mail =
                app.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem);
            mail.Subject = "This is coming from a C# script";
            mail.To = DistributionList; //your distribution list "email@something.com"
            mail.Body = "This is the body of an email from a C# script";
            mail.Attachments.Add(AttachmentDestination); //location of attachment (can be ommitted)
            mail.Send();
            app.Quit();
        }
