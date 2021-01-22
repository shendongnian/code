    var specifications = new List<ISpecification<Product>>();
    specifications.Add(
     new ProductCategoryNameSpecification("Tops"));
    specifications.Add(
     new ProductColorSpecification("Blue"));
    
    var products = ProductRepository.GetBySpecifications(specifications);
