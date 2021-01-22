    var biz = from b in ctx.Business where b.BusinessID == id
    select new 
    {
       Business = b,
       Contacts = b.Contacts.Where(c => c.ContactTypeID == x)
    }.ToList();
