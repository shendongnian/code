    public class Item
    {
       public string Name { get; set; }
    
       public Item(string name)
       {
           this.Name = name;
       }
    
       protected Item() {}
    }
    
    public class Armor : Item
    {   
       public Armor(string name) : base(name) {}
       protected Armor() {}
    }
    
    public class Helmet : Armor
    {   
       public Helmet(string name) : base(name) {}
       protected Helmet() {}
    }
