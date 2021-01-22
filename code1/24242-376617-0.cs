    using System;
    
    // this is your interface that will create the 
    // loose coupling that you want
    interface IProduct { void Ship(); }
    
    // make sure you generate your proxy code with
    // partial classes so you can then create your 
    // own parial class to implement the interface
    partial class ProductService : IProduct
    {
    	public void Ship()
    	{
    		// in here you would do validation
    		// and other things and then call the
    		// real ship method on the client
    	}
    }
    
    static class Factory
    {
    	public static IProduct GetProduct()
    	{
    		// configure away...do 
    		// whatever you need to do...
    
    		return new ProductService() as IProduct;
    	}
    }
