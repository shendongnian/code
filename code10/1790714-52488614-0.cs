    public class Form
    {
       public ICollection<Product> Products { get; set; } = new List<Product>();
    
       [NotMapped]
       public IReadOnlyCollection<Product> ActiveProducts => Products.Where(x => !x.Deleted).ToList().AsReadOnly();
       // or
       public IReadOnlyCollection<Product> ActiveProducts
       {
         get { return Products.Where(x => !x.Deleted).ToList().AsReadOnly();
       }
    }
