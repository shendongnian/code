    public class Region {
         public Guid ID { get; set; }
         public Guid Name { get; set; }
         public override string ToString()
         {
             return ID.ToString();
         }
    }
