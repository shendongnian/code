    public class Invoice
    {
         public int Id { get; set; }
         public int Transaction { get; set; }
         ...
         public IEnumerable<LineItem> LineItems { get; set; }
    }
    
    public class LineItem
    {
         public int Id { get; set; }
         ...
    }
