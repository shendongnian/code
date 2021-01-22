    `
    
    RequestSettings rs = new RequestSettings(this.ApplicationName, this.userName, this.passWord);
     // AutoPaging results in automatic paging in order to retrieve all contacts
     rs.AutoPaging = true;
     ContactsRequest cr = new ContactsRequest(rs);
    
     Feed<Contact> f = cr.GetContacts();
     foreach (Contact e in f.Entries)
     {
       Console.WriteLine("\t" + e.Title);
       foreach (EMail email in e.Emails)
       {
          Console.WriteLine("\t" + email.Address);
       }
       foreach (GroupMembership g in e.GroupMembership)
       {
          Console.WriteLine("\t" + g.HRef);
       }
       foreach (IMAddress im in e.IMs)
       {
          Console.WriteLine("\t" + im.Address);
       }
     }
    `
