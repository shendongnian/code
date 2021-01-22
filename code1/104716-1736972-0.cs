            ListDictionary replacements = new ListDictionary();
            string FromEmail= "from@yourwebsite.com";
            replacements.Add("{SITE_URL}", "http://yourwebsite.com");
            replacements.Add("{SITE_NAME}", "My site's name");
            //Create MailDefinition
            MailDefinition md = new MailDefinition();
            //specify the location of template
            md.BodyFileName = "~/Templates/Email/Welcome.txt";
            md.IsBodyHtml = true;
            md.From = FromEmail;
            md.Subject = "Welcome to youwebsite.com ";
            replacements.Add("{USERNAME}", "NewUser");
            System.Web.UI.Control ctrl = new System.Web.UI.Control { ID = "IDontKnowWhyThisIsRequiredButItWorks" };
            MailMessage message = md.CreateMailMessage("newuser@gmail.com", replacements, ctrl);
            //Send the message
            SmtpClient client = new SmtpClient();
            client.Send(message);
