    var result = myDbContext.Products            // from the collection of Products
        .Where(product => ...)                   // select only those Products that ...
        .Select(product => new                   // from every remaining Product make one new
        {                                        // object with the following properties:
             // Select only the properties you actually plan to use!
             Id = product.Id,
             Name = product.ProductName,
             ...
             AverageRating = product.Ratings       // from all Ratings of this Product
                 .Select(rating => rating.Rating)  // get the Rating value
                 .Average(),                       // and Average it.
             Images = product.Images               // from all Images of this product
                 .Select(image => image.ImagePath) // select the ImagePath
                 .ToList(),
             // or if a Product has only zero or one Image:
             Image = product.Image?.ImagePath // if the product has an Image, get its ImagePath
                                              // or use null if there is no Image
        });
