    public string ReturnAsCSV(ContactList contactList)
    {
        StringBuilder sb = new StringBuilder();
        foreach (Contact c in contactList)       
        { 
            sb.Append(c.Name + ",");       
        }
        if (sb.Length > 0)  
            sb.Length -= 1;
        return sb.ToString();  
    }
