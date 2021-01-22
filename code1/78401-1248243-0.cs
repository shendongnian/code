    public IEnmerable<SmsMessage> ParseFile(string filePath)
    {
        using (StreamReader file = new StreamReader(filePath))
        {
            string line;
            while ((line = file.ReadLine()) != null)
            {
                var sms = ParseLine(line);
                yield return sms;
            }
        }
    }
