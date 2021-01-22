    foreach (DictionaryEntry Emailentry in e.Values)
        {
            if (Emailentry.Key == "Email")
            {
                message.To.Add(new MailAddress(Emailentry.Value.ToString()));
            }
        }
