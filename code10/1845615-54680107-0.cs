    public class EntityAttribute
    {
       // ... properties, key, etc.
    
       public int IntValue { get; set; }
    
       [ForeignKey("IntValue")]
       public virtual IntAttribute MyInt { get; set; }
    }
