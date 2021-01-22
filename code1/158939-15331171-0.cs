            Application app = new Application();
            NameSpace ns = app.GetNamespace("mapi");
            ns.Logon("Email-Id", "Password", false, true);
            MailItem message = (MailItem)app.CreateItem(OlItemType.olMailItem);
            message.To = "To-Email_ID";
            message.Subject = "A simple test message";
            message.Body = "This is a test. It should work";
            
            message.Attachments.Add(@"File_Path", Type.Missing, Type.Missing, Type.Missing);
            
            message.Send();
            ns.Logoff();
