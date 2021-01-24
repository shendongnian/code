    private async void Submit_Clicked(object sender, EventArgs e) {
        try {
            ToggleIndicator(true);
            await SendEmailAsync();
            ToggleIndicator(false);
            await DisplayAlert("Success", "Message Sent. Thank you.", "Ok");
            myPop.IsVisible = false;
            myPop.IsEnabled = false;
        } catch (Exception ex) {
            await DisplayAlert("Error", "Something went wrong. Please try again.", "ok");
            Console.WriteLine(ex.ToString());
        }
    }
    
    private void ToggleIndicator(bool show) {
        indicator.IsRunning = show;
        indicator.IsVisible = show;
        indicator.IsEnabled = show;
        load.IsVisible = show;
    }
    
    private async Task SendEmailAsync() {
        MailMessage mail = new MailMessage();
        mail.From = new MailAddress("email@domain.com");
        mail.To.Add("email@domain.com");
        mail.Subject = "Subject";
        mail.Body = user_msg;
        SmtpClient SmtpServer = new SmtpClient("smtp.sendgrid.net");
        SmtpServer.Port = 25;
        SmtpServer.Credentials = new NetworkCredential("username", "password");
        SmtpServer.EnableSsl = true;
        ServicePointManager.ServerCertificateValidationCallback = delegate (object sendemail, X509Certificate certificate, X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors) {
            return true;
        };
        await SmtpServer.SendAsync(mail);
    }
    
