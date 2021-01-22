    public string ReturnAsCSV(ContactList contactList)
    {
        List<String> tmpList = new List<string>();
        foreach (Contact c in contactList)
        {
            tmpList.Add(c.Name);
        }
        return String.Join(",", tmpList.ToArray());
    }
