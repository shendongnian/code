    void ControllerMethod() // Root method
    {
         return ServiceA_MethodOne().GetAwaiter().GetResult();
    }
    
    // In another place in code
    Task ServiceA_MethodOne() 
    {
         return ServiceB_MethodOne();
    }
    
    // In another place in code
    async Task<List<Product>> ServiceB_MethodOne()
    {
         var data = await ctx.Products.ToListAsync();
         // some code here works with data.
    }
