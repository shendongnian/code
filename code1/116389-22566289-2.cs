    var myList = new List<Item>
                       { new Item() { UserId = 5, Name = "Alpha" },
                         new Item() { UserId = 5, Name = "Beta", UnRead = true },
                         new Item() { UserId = 6, Name = "Gamma", UnRead = false }
                       };
    
    
    myList.OperateOn(itm => itm.UserId == 5, itm => itm.UnRead = true);
    
    Console.WriteLine (string.Join(" ",
                                   myList.Select (itm => string.Format("({0} : {1})",
                                                                       itm.Name,
                                                                       itm.UnRead ))));
    
    /* Outputs this to the screen
    
    (Alpha : True) (Beta : True) (Gamma : False)
    
    */
...
    
    public class Item
    {
        public bool UnRead { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
    }
