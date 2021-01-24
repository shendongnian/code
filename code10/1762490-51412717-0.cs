    public static class Mapper
    {   
        public static ProductResponse Map(Product product)
        {
            return new ProductResponse
                       {
                          Name = product.Name,
                          Description = product.Description
                       };
        }
    
        public static BasketResponse Map(Basket basket)
        {
            return new BasketResponse
                       {
                           BasketCode = basket.Code,
                           Description = basket.Description,                
                           IntroMessage = basket.IntroMessage,
                           Products = basket.Products.Select(a => Mapper.Map(a))
                       };
        }
    }  
             
