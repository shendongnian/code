    public string ReturnAsCSV(ContactList contactList)
    {
        StringBuilder sb = new StringBuilder();
        bool isFirst = true;
        foreach (Contact c in contactList) {
            if (!isFirst) { 
              // Only add comma before item if it is not the first item
              sb.Append(","); 
            } else {
              isFirst = false;
            }
            sb.Append(c.Name);
        }
        return sb.ToString();
    }
