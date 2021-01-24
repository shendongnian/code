    void Main()
    {
    	var indexes = new List<int> { 1, 2, 5, 7, 10 };
    	
    	var orderedProducts = new List<Product>();
    	
    	orderedProducts.Add(new Product());
    	orderedProducts.Add(new Product());
    	orderedProducts.Add(new Product());
    	orderedProducts.Add(new Product());
    	orderedProducts.Add(new Product());
    	//orderedProducts.Add(new Product());//Add this in and you will see a result at index 5
    	//orderedProducts.Add(new Product());
    	//orderedProducts.Add(new Product());//7
    	//orderedProducts.Add(new Product());
    	//orderedProducts.Add(new Product());
    	//orderedProducts.Add(new Product());//10
    	
    	var myProducts = orderedProducts.Where((pr, i) => indexes.Any(x => x == i)).ToList();
    }
    
    public class Product
    {
    }
