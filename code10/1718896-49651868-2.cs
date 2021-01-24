    [HttpPost]
    public IActionResult Edit(ProductModel product)
    {
        if (!ModelState.IsValid)
        {
            return View(product);
        }
        var dbProduct = _productRepository.Query().FirstOrDefault(x => x.Id == product.Id);
        if (dbProduct == null)
        {
            //Product doesn't exist, create one, show an error page etc...
            //In this case we go back to index
            return RedirectToAction("Index", "Products");
        }
        //Now update the dbProduct using the data from your model
        dbProduct.ProductName = product.ProductName;
