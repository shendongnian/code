    public class DestinationType
    {
        public DestinationType(int A, int B, int C) { ... }
    }
    
    var newSet = from item in context.Items
        select new DestinationType(item.A, item.B, item.C);
    
    
