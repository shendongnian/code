    public static bool IsValidEmailString(string emailAddresses)
    {
        try
        {
            var addresses = emailAddresses.Split(',', ';')
                .Where(a => !string.IsNullOrWhiteSpace(a))
                .ToArray();
            var reformattedAddresses = string.Join(",", addresses);
            var dummyMessage = new System.Net.Mail.MailMessage();
            dummyMessage.To.Add(reformattedAddresses);
            return true;
        }
        catch
        {
            return false;
        }
    }
