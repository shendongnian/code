     if (model.Dynamic_ProductsSize.Count > 0)
    {
        foreach (var item in model.Dynamic_ProductsSize)
        {
            _sizes.Add(new ProductsSize(){SizeId = item});
        }
    }
