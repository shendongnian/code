    public void Foo()
    {
       CompanyDataContext db = new CompanyDataContext();
       Client client = (select c from db.Clients ....).Single();
       // makes it possible to call detach here
       client.Detach();
       Bar(client);
    }
    
    public void Bar(Client client)
    {
       CompanyDataContext db = new CompanyDataContext();
       db.Client.Attach(client);
       client.SomeValue = "foo";
       db.SubmitChanges();
    }
