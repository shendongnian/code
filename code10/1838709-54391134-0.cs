    public class DisplayProduct // create a little decorator
    {
         public DisplayProduct(Product prod, int pad)
         {
             Display = prod.Name.PadRight(pad) + prod.Price;
         }
         private Product Prod {get; set;}
        
         // if you plan to use Product properties, you can change scope and do
         // ((ProductDisplay)list.SelectedItem).Prod.Price
         public int Id {get{return Prod.Id;}}  
         public string Name {get{return Prod.Name;}} 
         public string Display {get; private set;} 
    }
    List<Product> products = GetList(...);
    int maxLen = products.Max(p => p.Name.Length) + 5;
    var diplayList = products.Select(p => new DisplayProduct(p, maxLen));
    myListBox.DisplayMember = "Display";
    myListBox.ValueMember = "Id";    
    myListBox.DataSource = diplayList;
