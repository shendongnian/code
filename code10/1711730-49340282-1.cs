    void Main()
    {
    	List<ProductDef> pdefs = new List<UserQuery.ProductDef>{
    		new ProductDef{Category = 1, Product = "Tools",  ParentCategory = 0},
    		new ProductDef{Category = 2, Product = "Hammer",  ParentCategory = 1},
    		new ProductDef{Category = 3, Product = "ScrewDriver",  ParentCategory = 1},
    		new ProductDef{Category = 4, Product = "Phillips",  ParentCategory = 3},
    		new ProductDef{Category = 5, Product = "Standard",  ParentCategory = 3},
    		new ProductDef{Category = 6, Product = "#2",  ParentCategory = 4},
    		new ProductDef{Category = 7, Product = "Torx",  ParentCategory = 3},
    		new ProductDef{Category = 8, Product = "#15",  ParentCategory = 7}
    	};
    	
        //This will get filled as we go
    	List<ProductHierarchy> phlist = new List<UserQuery.ProductHierarchy>();
    
    	//kick off the recursion
    	foreach (var element in pdefs)
    	{
    		Build(element, pdefs, element.Product, element.Category, phlist);
    	}
    	
    	//do stuff with your list
    	foreach (ProductHierarchy ph in phlist)
    	{
    		Console.WriteLine(ph.ToString());
    	}
    }
    
    class ProductDef
    {
    	public int Category { get; set; }
    	public string Product { get; set; }
    	public int ParentCategory { get; set; }
    }
    
    class ProductHierarchy
    {
    	public int Category { get; set; }
    	public string Hierarchy { get; set; }
    	public override string ToString()
    	{
    		return $"Category: {Category}, Hierarchy: {Hierarchy}";
    	}
    }
    
    void Build(ProductDef def, List<ProductDef> lst, string fullname, int cat, List<ProductHierarchy> phlist)
    {
    	string fullprodname = fullname;
    
    	//obtain the parent category of product
    	var parent = lst.FirstOrDefault(l => l.Category == def.ParentCategory);
    	if (parent != null)
    	{
    		fullprodname = $"{parent.Product}/{fullprodname}";
    		//recurse the call to see if the parent has any parents
    		Build(parent, lst, fullprodname, cat, phlist);
    	}
    	else
    	{
    		//No further parents found, add it to a list
    		phlist.Add( new ProductHierarchy { Category = cat, Hierarchy = fullprodname });	
    	}
    }
