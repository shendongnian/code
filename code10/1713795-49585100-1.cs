    public static class MailMessageFactory
    {
        public static IMailMessageFactory Default { get } =
            new MailMessageFactoryBuilder().Create();
    }
