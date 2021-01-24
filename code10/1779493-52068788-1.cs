	using (MailMessage mail = new MailMessage("ikwabe04@gmail.com", email, "TESTING THE SALARY SLIP EMAIL SENDER", "Habari Rafiki? Usishitushwe na ujumbe huu, tunajaribu system. Asante."))
	using (SmtpClient client = new SmtpClient("smtp.gmail.com"))
	using (Attachment file = new Attachment("C:/Users/" + Home.computerName + "/AppData/Roaming/SEC Payroll/Receipts/receipt.pdf"))
	{
		client.Port = 587;
		client.Credentials = new System.Net.NetworkCredential("ikwabe04@gmail.com", "mikunjoyamwili");
	    client.EnableSsl = true;      
        file.Name = "Salary Slip for " + DateTime.Now.ToString("MMMM yyyy") + ".pdf";
        mail.Attachments.Add(file);
        try
        {
            client.Send(mail);
            Login.RecordUserActivity("Sent the Salary Slip to " + email);
            sendInfo.ForeColor = Color.LightGreen;
            sendInfo.Text = "Email sent to: " + email + "     (" + DateTime.Now.ToLongTimeString() + ")";
            information.Controls.Add(sendInfo);
        }
        catch
        {
            sendInfo.ForeColor = Color.Orange;
            sendInfo.Text = "Email NOT sent to: " + email + "     ("+DateTime.Now.ToLongTimeString()+")";
            information.Controls.Add(sendInfo);
        }
    }
