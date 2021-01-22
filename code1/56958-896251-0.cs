// This is what LINQ-to-SQL will use:
private EntitySet&lt;Contact&gt; _Contacts = new EntitySet&lt;Contact&gt;();
[Association(Storage="_Contacts", OtherKey="CompanyID", ThisKey="ID")]
public EntitySet&lt;Contact&gt; Contacts
{
    get { return _Contacts; }
    set { _Contacts.Assign(value); }
}
// This is what MVC default model binder (and my View) will use:
public List&lt;Contact&gt; MvcContacts
{
    get { return _Contacts.ToList&lt;Contact&gt;(); }
    set { _Contacts.AddRange(value); }
}
