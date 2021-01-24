    var mimeMessage = new MimeMessage();
            mimeMessage.From.Add(new MailboxAddress("email", "intranet@domain.com"));
            foreach (var item in contacts)
            {
                mimeMessage.To.Add(new MailboxAddress(ToAdressTitle, string.Join(",", item.Email.ToString())));
            }
            mimeMessage.Subject = Subject;
            var builder = new BodyBuilder();                                             
                // Set the html version of the message text
                builder.HtmlBody = renderedView;
                // Now we just need to set the message body and we're done
                mimeMessage.Body = builder.ToMessageBody();
            
