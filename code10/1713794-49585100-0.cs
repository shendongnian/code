    public static class Mailer
    {
        public static IMailer Default
        {
            get { return new MailerBuilder().Create(); }
        }
    }
