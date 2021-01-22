    public string ReturnAsCSV(ContactList contactList)
    {
        if (contactList == null || contactList.Count == 0) return string.Empty;
        StringBuilder sb = new StringBuilder(contactList[0].Name);
        for (int i = 1; i < contactList.Count; i++)
        {
            sb.Append(",");
            sb.Append(contactList[i].Name);
        }
        return sb.ToString();
    }
