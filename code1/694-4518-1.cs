    public string ReturnAsCSV(ContactList contactList)
    {
        StringBuilder sb = new StringBuilder();
        foreach (Contact c in contactList)
        {
            sb.Append(c.Name + ",");
        }
        return sb.ToString().Trim(',');
    }
