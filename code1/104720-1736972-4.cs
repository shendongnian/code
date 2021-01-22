            ListDictionary replacements = new ListDictionary();
            // Replace hard coded values with objects values
            replacements.Add("{USERNAME}", "NewUser");            
            replacements.Add("{SITE_URL}", "http://yourwebsite.com");
            replacements.Add("{SITE_NAME}", "My site's name");
            string FromEmail= "from@yourwebsite.com";
            string ToEmail = "newuser@gmail.com";
            //Create MailDefinition
            MailDefinition md = new MailDefinition();
            //specify the location of template
            md.BodyFileName = "~/Templates/Email/Welcome.txt";
            md.IsBodyHtml = true;
            md.From = FromEmail;
            md.Subject = "Welcome to youwebsite.com ";
            System.Web.UI.Control ctrl = new System.Web.UI.Control { ID = "IDontKnowWhyThisIsRequiredButItWorks" };
            MailMessage message = md.CreateMailMessage(ToEmail , replacements, ctrl);
            //Send the message
            SmtpClient client = new SmtpClient();
            client.Send(message);
