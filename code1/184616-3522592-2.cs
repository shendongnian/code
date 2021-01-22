    public sealed class Food 
     {
         public string itemName {get; set;}
         public double unitPrice {get; set;}
         public double itemUnit {get; set;}
         public double getItemPrice() { return itemUnit * unitPrice; }
         public Food() : this("unknown food", 0);
         public Food(string item, double price) { itemName = item; unitPrice = price; }
           
         //you might want to rethink your customer object as well.  Are
         //you associating one customer with one item of food ?
     }
