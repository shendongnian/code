    public void UpdateInstanceGraph(OfferingInstance parentData, OfferingInstance offeringContainer = null)
	{
        ElementInstances  = parentData.ActiveServices
            .SelectMany(s => s.ActiveComponents)
            .SelectMany(c => c.Elements)
            .Where(e => e.PromotionId == PromotionSpecificationIdGuid).ToList();
    }
