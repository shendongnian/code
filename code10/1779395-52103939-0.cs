    //Create the message set request object to hold our request
    IMsgSetRequest addItemRequestMsgSet = sessionManager.CreateMsgSetRequest("US", 8, 0);
    addItemRequestMsgSet.Attributes.OnError = ENRqOnError.roeContinue;
    IItemServiceAdd itemServiceAddRq = addItemRequestMsgSet.AppendItemServiceAddRq();
    itemServiceAddRq.Name.SetValue(Item.Name);
    itemServiceAddRq.ORSalesPurchase.SalesOrPurchase.Desc.SetValue(Item.Description);
    itemServiceAddRq.ORSalesPurchase.SalesOrPurchase.ORPrice.Price.SetValue(Item.Price);
    itemServiceAddRq.ORSalesPurchase.SalesOrPurchase.AccountRef.FullName.SetValue("Some custom service description here");
    
    //...
    
