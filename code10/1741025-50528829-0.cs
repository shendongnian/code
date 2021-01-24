    Try this :
    private void button1_Click(object sender, EventArgs e)
    {
    sendMailToAdmin(textbox1.Text,textbox2.text);
    }
    
    protected void sendMailToAdmin(string uname, string email)
    {
        MailMessage myMsg = new MailMessage();
        myMsg.From = new MailAddress("****@mail.com");
        myMsg.To.Add(email);
        myMsg.Subject = "New User Email ";
        myMsg.Body = "New User Information\n\nUser Name: " + uname + "\nEmail : " + email;
    
        // your remote SMTP server IP.
        SmtpClient smtp = new SmtpClient();
        smtp.Host = "smtp.gmail.com";
        smtp.Port = 587;
        smtp.Credentials = new System.Net.NetworkCredential("****@mail.com", "pass***");
        smtp.EnableSsl = true;
        smtp.Send(myMsg);
    }
