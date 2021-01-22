    public string ReturnAsCSV(ContactList contactList)
    {
        StringBuilder sb = new StringBuilder();
        foreach (Contact c in contactList)
        {
            if (sb.Length > 0) { sb.Append(","); }
            sb.Append(c.Name);
        }
        return sb.ToString();
    }
