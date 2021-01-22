        public void ReadFileAndSend()
        {
            using (StreamReader reader = new StreamReader(@"d:\Email.txt"))
            {
                while (!(reader.ReadLine() == null))
                {
                    String line = reader.ReadLine();
                    if (line != "")
                    {
                        try
                        {
                            Send("", line.Trim());
                            Thread.Sleep(500);
                        }
                        catch
                        {
                        }
                    }
                }
                Console.ReadLine();
            }
        }
        public void Send(String FromAddress,String ToAddress)
        {
            try
            {
              
                string FromAdressTitle = "";
          
                string ToAdressTitle = "";
                string Subject = "";
                string BodyContent = "";
				string SmtpServer = "smtp.gmail.com";
                int SmtpPortNumber = 587;
                var mimeMessage = new MimeMessage();
                mimeMessage.From.Add(new MailboxAddress(FromAdressTitle, FromAddress));
                mimeMessage.To.Add(new MailboxAddress(ToAdressTitle, ToAddress));
                mimeMessage.Subject = Subject;
                mimeMessage.Body = new TextPart("html")
                {
                    Text = BodyContent
                };
                using (var client = new MailKit.Net.Smtp.SmtpClient())
                {
                    client.Connect(SmtpServer, SmtpPortNumber, false);
                    client.Authenticate("your email", "pass");
                    client.Send(mimeMessage);
                    Console.WriteLine("The mail has been sent successfully !!");
                    client.Disconnect(true);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
  
