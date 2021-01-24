    private IQueryable<OfferViewModel> GetOffersQueryForSeller(int sellerId, Func<Offer,bool> whereExtension)
    {
        return Db.Offers
            .Where(o => o.Sku.SellerId == sellerId && o.IsActive && !o.IsDiscontinued && whereExtension.Invoke(o))
                .Select(o => new OfferViewModel
                {
                    Id = o.Id,
                    Name = o.Sku.Name,
                    ImageUrl = o.Sku.ImageUrl ?? o.Sku.Upcq.Upc.ImageUrl,
                    QuantityName = o.Sku.QuantityName
                });
    }
    
    private IQueryable<OfferViewModel> GetOffersQueryForSeller(int sellerId)
    {
        return GetOffersQueryForSeller(sellerId, (o) => true);
    }
