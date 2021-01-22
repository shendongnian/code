    var fromAddress = new MailAddress("From");
                    var toAddress = new MailAddress("To");
                    string fromPassword = textBox4.Text;
                    const string subject = "Test";
                    const string body = "Test Finished";
    
                    var smtp = new SmtpClient
                    {
                        Host = "smtp.gmail.com",
                        Port = 587,
                        EnableSsl = true,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                        Credentials = new System.Net.NetworkCredential(fromAddress.Address, fromPassword)
                    };
                    using (var message = new MailMessage(fromAddress, toAddress)
                    {
                        Subject = subject,
                        Body = body
                    })
                    {
                        Attachment attachf = new Attachment("C:\\file.txt");
                        message.Attachments.Add(attachf);
                        smtp.Send(message);
                    }
                }
