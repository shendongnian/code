    private void SendDailyEmails()
        {
            var today = DateTime.Now;
            var recipient = "Test1@stanleytests.co.za,Test2 @stanleytests.co.za";
            var message = new MailMessage()
            {
                From =  new MailAddress("Somebody"),
                CC = { new MailAddress("me@stanleytests.co.za") },
                Subject = "Daily Mail",
                Body = @"Good morning, <br/><br/> This email is sent to you: <strong> ""please be adviced"" </strong> <br/><br/>Regards",
                IsBodyHtml = true
            };
            foreach (var i in recipient.Split(',').ToList())
            {
                message.To.Add(new MailAddress(i));
            }
            // do your "_emailService.SendEmail(message);
        }
