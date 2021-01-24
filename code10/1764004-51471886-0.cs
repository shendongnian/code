    public void Execute()
    {
       var provisioningRepo = _containerFactory.GetInstance<IProvisioningRepo>();
       var discounts = provisioningRepo.GetDiscounts();
       if (discounts.Count == 0)
         return;
       discounts = MakeLogicThingsWithDiscount(discounts);
    }
    
    private IEnumerable<Discount> MakeLogicThingsWithDiscount(IEnumerable<Discount> discounts)
    {
       //make logic things here
    }
