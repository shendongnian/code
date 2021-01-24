      List<Products> p= new List<Products>();
      p.Add(new Products { name = "Health Ins", cost = 100 });
      p.Add(new Products { name = "Travel Ins", cost = 150 });
    
       members.Add(new Member { memberNumber = 1234567890, forename = "Fred", surname = "Smith", Products =p});
     // Second member
         p= new List<Products>();
         p.Add(new Products { name = "Big Bens products", cost = 222});        
         members.Add(new Member { memberNumber = 1, forename = "Big", surname = "Ben", Products =p});
        
                    
