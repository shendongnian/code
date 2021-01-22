    public static void sendEmail()
        {
            //for use GMAIL require enable - 
            //https://myaccount.google.com/lesssecureapps?rfn=27&rfnc=1&eid=39511352899709300&et=0&asae=2&pli=1
            Console.WriteLine("START MAIL SENDER");
            //Авторизация на SMTP сервере
            SmtpClient Smtp = new SmtpClient("smtp.gmail.com", 587);
            Smtp.EnableSsl = true;
            Smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            Smtp.UseDefaultCredentials = false;
             //username   password
            Smtp.Credentials = new NetworkCredential("rere", "rere");
 
            //Формирование письма
            MailMessage Message = new MailMessage();
            Message.From = new MailAddress("rere@gmail.com");
            Message.To.Add(new MailAddress("rere@gmail.com"));
            Message.Subject = "test mesage";
            Message.Body = "tttt body";
            string file = "D:\\0.txt";
            if (file != "")
            {
                Attachment attach = new Attachment(file, MediaTypeNames.Application.Octet);
                ContentDisposition disposition = attach.ContentDisposition;
                disposition.CreationDate = System.IO.File.GetCreationTime(file);
                disposition.ModificationDate = System.IO.File.GetLastWriteTime(file);
                disposition.ReadDate = System.IO.File.GetLastAccessTime(file);
                Message.Attachments.Add(attach);
                Console.WriteLine("ADD FILE [" + file + "]");
            }
            try
            {
                Smtp.Send(Message);
                MessageBox.Show("SUCCESS");
            }
            catch { MessageBox.Show("WRONG"); }
        }
