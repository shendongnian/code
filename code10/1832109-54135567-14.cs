    var verify = new Verify(); 
    //try to purchase item
    // Here is where you pass in the class that implements IInAppBillingVerifyPurchase.VerifyPurchase method
    var purchase = await CrossInAppBilling.Current.PurchaseAsync(productId, ItemType.InAppPurchase, "apppayload", verify); 
	if(purchase == null)
	{
		//Not purchased, may also throw excpetion to catch
	}
	else
	{
		//Purchased!
	}
