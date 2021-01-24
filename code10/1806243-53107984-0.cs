    private static List<Plan> MakePlans(IEnumerable<Plan> plans, int pid)
    {
        return plans
                .Where(plan => plan.ProductId == pid)
                .Select(plan => new PaymentPlan
                {
                    Name = plan.Nickname,
                    Id = plan.Id,
                    Price = plan.Tiers ?? new List<PlanTier>
                    {
                        new PlanTier
                        {
                            UnitAmount = plan.Amount.GetValueOrDefault(),
                            UpTo = null
                        }
                    },
                }).ToList();
    }
    public static IEnumerable<SubscriptionOfferList> GetSubscriptionOffers(this IEnumerable<Product> products, IEnumerable<Plan> plans) =>
         products
             .GroupBy(p => p.Metadata["SubscriptionType"])
             .Select(productGroup => new SubscriptionOfferList
             {
                Name = productGroup.Key,
                Offers = productGroup.Select(p => new SubscriptionOffer
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Metadata["SubscriptionPrice"],
                    Plans = MakePlans(plans, p.Id)
                }).ToList(),
             });
