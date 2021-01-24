    subscriptionStoreProduct = await GetSubscriptionProductAsync();
    if (subscriptionStoreProduct == null)
    {
        return;
    }
    // Check if the first SKU is a trial and notify the customer that a trial is available.
    // If a trial is available, the Skus array will always have 2 purchasable SKUs and the
    // first one is the trial. Otherwise, this array will only have one SKU.
    StoreSku sku = subscriptionStoreProduct.Skus[0];
    if (sku.SubscriptionInfo.HasTrialPeriod)
    {
        // You can display the subscription trial info to the customer here. You can use 
        // sku.SubscriptionInfo.TrialPeriod and sku.SubscriptionInfo.TrialPeriodUnit 
        // to get the trial details.
    }
    else
    {
        // You can display the subscription purchase info to the customer here. You can use 
        // sku.SubscriptionInfo.BillingPeriod and sku.SubscriptionInfo.BillingPeriodUnit
        // to provide the renewal details.
    }
