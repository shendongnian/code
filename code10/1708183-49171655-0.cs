    if(BacksplashProduct != null)
    {
    	//YOu missed assignment here
    	BacksplashProduct.lstBacksplashTile = new List<BackSplashTileGuideViewModel>(); 
    	
    	var products = BacksplashProduct.MultipleProduct.Split(',');
    	for (int i = 0; i < products.Length; i++)
    	{
    		var detail = AllProducts.Where(x => x.ID == Convert.ToInt32(products[i])).Select(y => new {y.ID ,y.ProductName,y.Descriptions }).FirstOrDefault();
    
    		BacksplashProduct.ProductID = detail.ID;
    		BacksplashProduct.ProductDescription = detail.Descriptions;
    		BacksplashProduct.ProductsName = detail.ProductName;
    		BacksplashProduct.lstBacksplashTile.Add(BacksplashProduct);
    	}
    	return View(BacksplashProduct);
    }
