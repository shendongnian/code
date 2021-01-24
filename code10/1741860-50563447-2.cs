    public async Task<IEnumerable<ProductDto>> GetProductsAsync(bool isLogged)
    {
        return await _mapper.GetStripeProductsDto(isLogged, false);
    }
    public async Task<IEnumerable<StripeProduct>> GetAllStripeProductsAsync()
    {
        var list = await _productService.ListAsync();
        return await list.Where(x => x.Type == "good" && x.Active == true).ToListAsync();
    }
    public async Task<IEnumerable<ProductDto>> GetStripeProductsDtoAsync(bool isLogged, bool isSubscriber)
    {
        // here you're making async call and when task is done, you are making .ToList() on results
        var productList = await _productRepo.GetAllStripeProductsAsync();
        // this will be executed when productList has results from database (task).
        // Because GetSkuOffers() method is sync you can execute this like below.
        var skuOffersResult = GetSkuOffers(productList);
        // get asynchronously subscription offers
        var getSubscriptionOffers = await GetSubsciptionOffers(productList);
        // this is done also synchronously so you don't need to use async/await statements
        skuOffersResult.Concat(getSubscriptionOffers)
                    .GroupBy(product => product.Name)
                    .Select(productGroup => new ProductDto
                    {
                        Name = productGroup.Key,
                        Id = productGroup.Select(product => product.Id).First(),
                        Description = productGroup.Select(product => product.Description).First(),
                        Image = productGroup.Select(product => product.Image).First(),
                        CurrentUserProfile = isSubscriber
                            ? OfferTypeEnum.Pro.ToString()
                            : isLogged
                                ? OfferTypeEnum.Registered.ToString()
                                : OfferTypeEnum.Basic.ToString(),
                        Prices = productGroup.Select(product => new
                        {
                            Offer = product.OfferType.ToString(),
                            Price = product.Price.ToString()
                        })
                        .ToDictionary(p => p.Offer, p => p.Price)
                    })
                    .ToList());
    }
    private IEnumerable<Product> GetSkuOffers(IEnumerable<StripeProduct> productList)
    {
        return productList
            .SelectMany(sku => sku.Skus.Data, (product, sku) => new Product
            {
                Name = product.Name,
                Id = product.Id,
                Image = new Uri(product.Images.First()),
                Description = product.Description,
                OfferType = sku.Id.Contains("Basic") ? OfferTypeEnum.Basic : OfferTypeEnum.Registered,
                Price = sku.Price
            });
    }
    private async Task<IEnumerable<Product>> GetSubsciptionOffers(IEnumerable<StripeProduct> productList)
    {
        return
            productList
            .Select(async product => new Product
            {
                Name = product.Name,
                Id = product.Id,
                Image = new Uri(product.Images.First()),
                Description = product.Description,
                OfferType = OfferTypeEnum.Pro,
                Price = (await _planRepo.GetPlanByIdAsync(product.Metadata.First().Value)).Amount.GetValueOrDefault()
            });
    }
