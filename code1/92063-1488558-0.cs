    public class Invoice
    {
       // Setters are private to avoid modifying the values.
       public String PartNumber { get; private set; }
       public String Description { get; private set; }
       public Decimal Price { get; private set; }
       // Quantity has public setter and is an unsigned integer.
       public UInt32 Quantity { get; set; }
       // Computed property for the total.
       public Decimal Total
       {
          get { return this.Quantity * this.Price; }
       }
    
       public Invoice(String partNumber, String description, UInt32 quantity, Decimal price)
       {
          // Check for non-negative price.
          if (price < 0.00M)
          {
              throw new ArgumentOutOfRangeException();
          }
          // Maybe check part number and description, too.
          this.PartNumber = partNumber;
          this.Description = description;
          this.Price = price;
          this.Quantity = quantity;
       }
    }
