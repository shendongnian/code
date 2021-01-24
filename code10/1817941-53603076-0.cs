    var existingEmails = new HashSet<String>();
    foreach (String email in MyToList)
    {
       if(!existingEmails.ContainsKey(email)
       {
           msg.AddTo(email);
           existingEmails.Add(email);
       }
    }
    foreach (String email in MyCCList)
    {
       if(!existingEmails.ContainsKey(email)
       {
           msg.AddCC(email);
           existingEmails.Add(email);
       }
    }
    foreach (String email in MyBCCList)
    {
       if(!existingEmails.ContainsKey(email)
       {
           msg.AddBCC(email);
           existingEmails.Add(email);
       }
    }
