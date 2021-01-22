    // Here's your object that you'll create a list of
    private class Products
    {
    	public string ProductName { get; set; }
    	public string ProductDescription { get; set; }
    	public string ProductPrice { get; set; }
    }
    
    // Here you pass in the List of Products
    private void BindItemsInCart(List<Products> ListOfSelectedProducts)
    {	
    	// The the LIST as the DataSource
    	this.rptItemsInCart.DataSource = ListOfSelectedProducts;
    
    	// Then bind the repeater
    	// The public properties become the columns of your repeater
    	this.rptItemsInCart.DataBind();
    }
