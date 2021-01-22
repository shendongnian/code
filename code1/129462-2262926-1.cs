    PeopleDataContext people = new PeopleDataContext();
     
    using (TransactionScope t = new TransactionScope())
    {
       Person p = people.People.Single(person => person.ID == 1);
     
       p.LastName = "Pessimistic";
       p.FirstName = "Concurrency";    
           
       people.SubmitChanges();     
       t.Complete();
    }
