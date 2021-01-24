    private IQueryable<OfferViewModel> GetOffersQueryForSeller(int sellerId, Func<Offer,bool> whereExtension)
    {
        return Db.Offers
            .Where(o => ... && whereExtension.Invoke(o))
            .Select(o => new OfferViewModel { ... });
    }
    
    private IQueryable<OfferViewModel> GetOffersQueryForSeller(int sellerId)
    {
        return GetOffersQueryForSeller(sellerId, (o) => true);
    }
