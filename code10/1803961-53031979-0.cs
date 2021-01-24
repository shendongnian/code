     var newPhone = new Phone(); 
     newPhone.PhoneNumber = newNumber;
    
     try 
     {
        pdb.Phones.Add(newPhone);
        pdb.SaveChanges();
     }
     catch (Exception e) 
     {
        Console.WriteLine("COULD NOT ADD new number: {0}", e.Message);
     }
