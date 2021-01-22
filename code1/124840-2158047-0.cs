    public abstract class Item
    {
       public string Name { get; set; }
    }
    
    public abstract class Armor : Item
    { }
 
    public class Helmet : Armor
    { }
