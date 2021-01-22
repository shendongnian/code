    var myList = new[] { new Item() { UserId = 5, Name = "Alpha" },
                         new Item() { UserId = 5, Name = "Beta", UnRead = true },
                         new Item() { UserId = 6, Name = "Gamma", UnRead = false }
                       };
    
    myList.Where (itm =>
            {
                if (itm.UserId == 5)
                    itm.UnRead = true;
    
                return itm.UserId == 5;
            }
            )
          .FirstOrDefault(); // Deferred execution; doesn't process till the list is actually accessed.
    
    Console.WriteLine (string.Join(" ", myList.Select (itm => string.Format("({0} : {1})", itm.Name, itm.UnRead ))));
    
    /* Outputs this to the screen
    
    (Alpha : True) (Beta : True) (Gamma : False)
    
    */
    
    public class Item
    {
        public bool UnRead { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
    }
