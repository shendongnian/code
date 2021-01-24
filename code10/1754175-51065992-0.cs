    public async Task<bool> TestMakePurchase(string productId, string payload)
    {
    	var billing = CrossInAppBilling.Current;
    	try
    	{
    		// Snip
    	}
    	catch (InAppBillingPurchaseException purchaseEx)
    	{
    		
    	}
    	finally
    	{
    		await billing.DisconnectAsync();
    	}
    
        // Add this line
    	return false;
    }
