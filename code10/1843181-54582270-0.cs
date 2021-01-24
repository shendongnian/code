    public static async Task SendMailsOnebyOneAsync() {
        using (var sMail = new SmtpClient("XXX")) {
            sMail.DeliveryMethod = SmtpDeliveryMethod.Network;
            sMail.UseDefaultCredentials = false;
            sMail.Credentials = null;
            for (int i = 0; i < 1000; i++) {
                try {
                    var fromMailAddress = new MailAddress("XXX");
                    var toMailAddress = new MailAddress("XXX");
                    var message = new MailMessage(fromMailAddress, toMailAddress) {
                        Subject = "test"
                    };
                    await sMail.SendMailAsync(message);
                    Console.WriteLine("Sent {0}", i);
                } catch (Exception e) {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
