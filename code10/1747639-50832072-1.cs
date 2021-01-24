    (product, images) => new        // for every product with matching images make new:
    {
        ProductId = product.Id,
        Name = product.Name,
        ImageData = images.Select(image => new
        {
            Image = image.Image, 
            ProductImageId = image.ProductImageId.ToString(),
         })
         .FirstOrDefault() ??             // select the first image name
         new                              // or use a default if there is none
         {
              Image = "noproductImage.jpg",
              ProductImageId = "NoId",
         },
    });
