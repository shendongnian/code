    public class ContactController : Controller
    {
        [HttpPost]
        public ActionResult Send(ContatcViewModel model) {
            if (ModelState.IsValid) {
                // example code from link
                try
                {
                    MailMessage mail = new MailMessage();
                    SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                    mail.From = new MailAddress("your_email_address@gmail.com");
                    mail.To.Add("to_address");
                    mail.Subject = "Test Mail";
                    mail.Body = "This is for testing SMTP mail from GMAIL";
                    SmtpServer.Port = 587;
                    SmtpServer.Credentials = new System.Net.NetworkCredential("username", "password");
                    SmtpServer.EnableSsl = true;
                    SmtpServer.Send(mail);
                    MessageBox.Show("mail Send");
                }
                catch (Exception ex)
                {
                    // code
                }
            }
        
            return View();
        }
    }
