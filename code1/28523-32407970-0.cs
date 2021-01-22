    private string GetProperlyFormattedEmailString(string emailString)
        {
            var emailStringParts = CSVProcessor.GetFieldsFromString(emailString);
            string emailStringProcessed = "";
            foreach (var part in emailStringParts)
            {
                try
                {
                    var address = new MailAddress(part);
                    emailStringProcessed += address.Address + ",";
                }
                catch (Exception)
                {
                    //wasn't an email address
                    throw;
                }
            }
            return emailStringProcessed.TrimEnd((','));
        }
