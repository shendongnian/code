    public abstract class Item
    {
       public abstract string Name { get; set; }
    }
    
    public abstract class Armor : Item
    {
       public abstract override string Name { get; set; }
    }
    
    public abstract class Helmet : Armor
    {
       public abstract override string Name { get; set; }
    }
