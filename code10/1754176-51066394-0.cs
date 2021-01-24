    public async Task<bool> TestMakePurchase(string productId, string payload)
    {	
    	var purchaseSuccesful = false;
    	var billing = CrossInAppBilling.Current;
    	try
    	{									
    		if (await billing.ConnectAsync())
    		{                 
    			var purchase = await billing.PurchaseAsync(productId, ItemType.InAppPurchase, payload);
    			purchaseSuccesful = purchase != null;
    		}
    	}
    	catch (InAppBillingPurchaseException purchaseEx)
    	{
    		//log this error?
    	}
    	finally
    	{
    		await billing.DisconnectAsync();
    	}
    	
    	return purchaseSuccesful;
    }
