    var biz = ctx.Business.Where(b => b.BusinessID == id).Single(); 
    var contacts = ctx.Contacts.Where(c => c.BusinessID==id && c.ContactTypeID==6);
    foreach (var contact in contacts)
    {
       biz.Contacts.Add(contact);
    }
