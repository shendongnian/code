    // perform the linq-to-entities query, query execution is triggered by ToArray()
    var data =
       (from c in Context.Contacts
       select new {
           c.ContactID,
           c.FullName,
           c.LocationID
       }).ToArray();
    // at this point, the database has been called and we are working in
    // linq-to-objects where ToString() is supported
    // Key2 is an extra example that wouldn't work in linq-to-entities
    var data2 =
       (from c in data
        select new {
           c.FullName,
           ContactLocationKey = c.ContactID.ToString() + "." + c.LocationID.ToString(),
           Key2 = string.Join(".", c.ContactID.ToString(), c.LocationID.ToString())
        }).ToArray();
