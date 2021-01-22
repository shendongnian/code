    public string ReturnAsCSV(ContactList contactList)
    {
        StringBuilder sb = new StringBuilder();
        using (StringWriter stringWriter = new StringWriter(sb))
        {
            using (var csvWriter = new CsvHelper.CsvWriter(stringWriter))
            {
                csvWriter.Configuration.HasHeaderRecord = false;
                foreach (Contact c in contactList)
                {
                    csvWriter.WriteField(c.Name);
                }
            }
        }
        return sb.ToString();
    }
