    static void Main(string[] args)
    {     
        Product p1 = new Product(1, 20, 1000);
    
        Inventory inv = new Inventory();
        ProductManagement p = new ProductManagement(inv); //THE CHANGE
        
        inv.AddProduct(p1);
        
        p.productSold(p1);
        
        inv.ViewInventory();
    
        Console.ReadLine();
    }
