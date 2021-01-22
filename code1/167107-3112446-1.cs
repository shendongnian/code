    public class Book
    {
       public Book(string name, string price)
       {
          Name = name;
          Price = price;
       }
       public string Name { get; set; }
       public string Price { get; set; } // could be decimal if we want a proper type.
    }
