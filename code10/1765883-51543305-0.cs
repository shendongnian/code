    void Main()
    {
        DataContext db = new DataContext(@"server=.\SQLexpress;trusted_connection=yes;database=Northwind");
        
        Table<Category> Categories = db.GetTable<Category>();
        Table<Product> Products = db.GetTable<Product>();
       
        Form f = new Form { Text="ComboBox ornek", Height=200, Width=500 };
        ComboBox cb1 = new ComboBox{ Left=10, Top=10, Width=450, Font=new Font("Courier New",8) };
        ComboBox cb2 = new ComboBox{ Left=10, Top=60, Width=450, Font=new Font("Courier New",8) };
        
        f.Controls.AddRange( new Control[] {cb1, cb2} );
    
        cb1.DataSource = Categories.OrderByDescending(c => c.CategoryName).ToList();
        cb1.ValueMember = "CategoryId";
        cb1.DisplayMember = "CategoryName";
        //cb1.SelectedIndex = -1;
    	
    
        cb1.SelectedIndexChanged += (sender, args) => { 
        
        var selectedCategory = ((ComboBox)sender).SelectedItem as Category;
        cb2.DataSource = null;
        cb2.Items.Clear();
        if (selectedCategory != null)
        {
          cb2.DataSource = Products.Where (p => p.CategoryId == selectedCategory.CategoryId).ToList();
          cb2.DisplayMember = "ProductName";
          cb2.ValueMember = "ProductId";
        }
        };
    
    	cb1.SelectedValue = 5;
    	f.ShowDialog();
    }
    
    
    [Table(Name = "Categories")]
    public class Category
    {
        [Column]
        public int CategoryId { get; set; }
        [Column]
        public string CategoryName { get; set; }
        [Column]
        public string Description { get; set; }
    }
    
    [Table(Name = "Products")]
    public class Product
    {
        [Column]
        public int ProductId { get; set; }
        [Column]
        public string ProductName { get; set; }
        [Column]
        public int CategoryId { get; set; }
    }
