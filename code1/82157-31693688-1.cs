    private void btnTestConnection_Click(object sender, EventArgs e)
         {
        btnTestConnection.Enabled = false;
        SmtpClient ss = new SmtpClient(txtSmtpHostName.Text.Trim(), Convert.ToInt32(numSmtpHostPort.Value));
        ss.EnableSsl = chkSmtpSecureType.Checked;
        ss.Timeout = 10000;
        ss.DeliveryMethod = SmtpDeliveryMethod.Network;
        ss.UseDefaultCredentials = false;
        ss.Credentials = new NetworkCredential(txtSmtpAccount.Text.Trim(), txtSmtpPassword.Text);
    
        MailMessage mm = new MailMessage(txtSmtpFromEmail.Text.Trim(), "test@domain.com", "subject", "my body");
        mm.BodyEncoding = UTF8Encoding.UTF8;
        mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
        ss.SendCompleted += (s, b) =>
        {
            ss.Dispose();
            mm.Dispose();
        };
        try
        {
            ss.Send(mm);
            ss.Dispose();
            mm.Dispose();
            MessageBox.Show("Connection successfully");
        }
        catch (Exception ep)
        {
            MessageBox.Show("Connection error: " + ep.Message, "Smtp Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        btnTestConnection.Enabled = true;
    }
