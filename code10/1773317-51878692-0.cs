        public static Microsoft.Office.Interop.Outlook.Application GetActiveOutlookApplication()
        {
            return (Microsoft.Office.Interop.Outlook.Application)System.Runtime.InteropServices.Marshal.GetActiveObject("Outlook.Application");
        }
        public void SendMailToUser()
        {
            try
            {
                Outlook.Application app = new Outlook.Application();
                Outlook.MailItem mail = app.CreateItem(Outlook.OlItemType.olMailItem) as Outlook.MailItem;
                mail.Subject = "Test mail";
                mail.Body = "Test";
                Outlook.AddressEntry currentUser = app.Session.CurrentUser.AddressEntry;
                if (currentUser.Type == "EX")
                {
                    Outlook.ExchangeUser user = currentUser.GetExchangeUser();
                    // Add recipient using display name, alias, or smtp address
                    mail.Recipients.Add(user.PrimarySmtpAddress);
                    mail.Recipients.ResolveAll();
                    mail.Attachments.Add(@"URL", Outlook.OlAttachmentType.olByValue, Type.Missing, Type.Missing);
                    mail.Send();
                }
            }
            catch (Exception ex)
            {
            }
        }
