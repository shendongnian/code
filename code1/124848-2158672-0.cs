    public abstract class Item
    {
       public virtual string Name 
       { 
             get {return m_strName;} 
             set {m_strName = value;}
       }
    
    public abstract class Armor : Item
    {
       public override string Name { get; set; } // if you want to override it 
    }
    
    public class Helmet : Armor
    {
       public override string Name { get; set; } // if you want to override it
    }
