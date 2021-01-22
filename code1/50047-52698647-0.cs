    private void sendAMail(String toAddress, String messageBody)
            {
                String msg = "Sending mail to : " + toAddress;
    
                MailMessage mail = new MailMessage();
                mail.To.Add(toAddress);
                mail.From = new MailAddress("from@mydomain.com");
                mail.Subject = "Subject: Test Mail";
                mail.Body = messageBody;
                mail.IsBodyHtml = true;            
    
                //Added this line here
                System.Net.ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(RemoteServerCertificateValidationCallback);
                SmtpClient smtp = new SmtpClient();
    
                smtp.Host = "myhostname.com";            
                smtp.Credentials = new System.Net.NetworkCredential("sender@sample.com", "");
                smtp.EnableSsl = true;
                smtp.Port = 587;            
                smtp.Send(mail);            
            }
    
    
    private bool RemoteServerCertificateValidationCallback(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certificate, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
    {
        //Console.WriteLine(certificate);
        return true;
    }
