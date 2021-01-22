    private static IEnumerable<MailAddress> ParseAddress(string addresses)
    {
        var mailAddressParserClass = Type.GetType("System.Net.Mail.MailAddressParser");
        var parseMultipleAddressesMethod = mailAddressParserClass.GetMethod("ParseMultipleAddresses", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static);
        return (IList<MailAddress>)parseMultipleAddressesMethod.Invoke(null, new object[0]);
    }
    
        private static IEnumerable<MailAddress> ParseAddress(string addresses)
        {
            MailMessage message = new MailMessage();
            message.To.Add(addresses);
            return new List<MailAddress>(message.To); //new List, because we don't want to hold reference on Disposable object
        }
