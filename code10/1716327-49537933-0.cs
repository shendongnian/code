    CatalogManager catalogManager = CatalogManager.GetManager();
    // Get the old unused product
    Product oldProduct = catalogManager.GetProduct(oldProduct.Sku, ContentLifecycleStatus.Live);
    // Set the english and french URLs to something new
    oldProduct.UrlName.SetString(enCulture, "new-english-product-name");
	oldProduct.UrlName.SetString(frCulture, "new-french-product-name");
	// Delete associated non-default URLs
	List<ProductUrlData> urls = oldProduct.Urls.Where(u => !u.IsDefault).ToList();
	if (urls.Count > 1)
	{
		oldProduct.Urls.ClearUrls(true);
		for (int i = urls.Count - 1; i >= 0; i--)
		{
			catalogManager.Provider.Delete(urls[i]);
		}
	}
    // Recompile the URLs and save changes
    catalogManager.Provider.RecompileItemUrls(oldProduct);
	catalogManager.SaveChanges();
