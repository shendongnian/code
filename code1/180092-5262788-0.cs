    public void SetPersonName(int personID, string personName)
    {
         var context = new PersonContext(myConnectionString);
         var person = context.Persons.Where(x => x.PersonID == personID).FirstOrDefault();
         
         if(person == null)
         {
              throw new InvalidOperationException("Boo Hoo, person ID is invalid");
         }
    
         person.Name = personName;
         context.SaveChanges();
    }
