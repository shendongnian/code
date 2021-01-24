    public static class MailAddressExtension
    {
        private static Regex AliasRegex = new Regex(@"\+([A-Za-z0-9]+)");
        public static List<string> Alias(this MailAddress mail)
        {
            return AliasRegex.Matches(mail.User).Select(a => a.Groups[1].Value).ToList();
        }
    }
