    var allLines=new List<orderConfirmation>();
    foreach (var item in orderedLineItems)
    {
        if (item.SubscriptionQuantity == 0)
        {
            prd = item.ProductName;
            qty = item.SingleOrderQuantity;
            prc = item.SingleOrderPrice;
        }
        else
        {
            prd = item.ProductName;
            qty = item.SubscriptionQuantity;
            prc = item.SubscriptionPrice;
        }
        var body = new orderConfirmation
        {
            receipt = true,
            lineItem = new lineItem
            {
                product = prd,
                quantity = qty,
                //price = prc
            },
            total = "CHF " + order.OrderAmount.ToString(),
            company = DATADB.ShippingAddressList.Where(x => x.UserID == userID).Where(x => x.IsDefaultShippingAddress == true).Select(x => x.ShippingAddressCompanyName).First(),
            name = UserManager.FindById(userID).FirstName.ToString() + " " + UserManager.FindById(userID).LastName.ToString(),
            address01 = DATADB.ShippingAddressList.Where(x => x.UserID == userID).Where(x => x.IsDefaultShippingAddress == true).Select(x => x.ShippingAddressStreet).First() + " " + DATADB.ShippingAddressList.Where(x => x.UserID == userID).Where(x => x.IsDefaultShippingAddress == true).Select(x => x.ShippingAddressNumber).First(),
            address02 = DATADB.ShippingAddressList.Where(x => x.UserID == userID).Where(x => x.IsDefaultShippingAddress == true).Select(x => x.ShippingAddressAdditional).First(),
            zip = DATADB.ShippingAddressList.Where(x => x.UserID == userID).Where(x => x.IsDefaultShippingAddress == true).Select(x => x.ShippingAddressZIP).First(),
            city = DATADB.ShippingAddressList.Where(x => x.UserID == userID).Where(x => x.IsDefaultShippingAddress == true).Select(x => x.ShippingAddressCity).First(),
            state = DATADB.ShippingAddressList.Where(x => x.UserID == userID).Where(x => x.IsDefaultShippingAddress == true).Select(x => x.ShippingAddressState).First(),
            instructions = DATADB.ShippingAddressList.Where(x => x.UserID == userID).Where(x => x.IsDefaultShippingAddress == true).Select(x => x.ShippingInstructions).First()
        };
      allLines.Add(body);
    };
    msg.SetTemplateData(allLines);
