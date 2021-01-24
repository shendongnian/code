    // You could use await if your method is async, for simplicity just Result.
      IHttpActionResult actionResult = new ProductsController().GetProducts(_params).Result;
    
    // if your result is a Product Type
      var contentResult = actionResult as OkNegotiatedContentResult<Product>;
      Product product = contentResult.Content;
    
    // Map to your DTO class for example
       ProductDto dto = new ProductDto()
       {
            Id = product.Id,
            Name = product.Name
        };
