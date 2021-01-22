    private void btnSent_Click(object sender, EventArgs e)
    {
        try
        {
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            mail.From = new MailAddress(txtAcc.Text);
            mail.To.Add(txtToAdd.Text);
            mail.Subject = txtSub.Text;
            mail.Body = txtContent.Text;
            System.Net.Mail.Attachment attachment;
            attachment = new System.Net.Mail.Attachment(txtAttachment.Text);
            mail.Attachments.Add(attachment);
            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential(txtAcc.Text, txtPassword.Text);
            SmtpServer.EnableSsl = true;
            SmtpServer.Send(mail);
            MessageBox.Show("mail send");
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString());
        }
    }
    private void button1_Click(object sender, EventArgs e)
    {
        MailMessage mail = new MailMessage();
        openFileDialog1.ShowDialog();
        System.Net.Mail.Attachment attachment;
        attachment = new System.Net.Mail.Attachment(openFileDialog1.FileName);
        mail.Attachments.Add(attachment);
        txtAttachment.Text =Convert.ToString (openFileDialog1.FileName);
    }
