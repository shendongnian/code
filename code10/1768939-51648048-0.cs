     using(YourDbContext dc = new YourDbContext())
     {
       person prs = new person();
       prs.Name = "person1";
       prs.FatherName = "Father1";
       ...
       prs.Addresses.Add(
         new Address()
         {
            Address = "Address1 No1",
            Tel = "000000",
            ...
         });
       prs.Accounts.Add(
         new Account()
         {
            AccountNumber = "123456",
            CardNumber = "000000"
            ....
         }); 
       dc.Persons.Add(prs);
       dc.SaveChanges();
     }
    
