    // Increase the size
    Array.Resize(ref paypalItems, paypalItems.Length + 1);
    // add Coupons & Discounts line item
    paypalItems[paypalItems.Length -1] = new PaymentDetailsItemType
                                              {
                                                  Name = "Gift Cards",
                                                  Amount = ApiUtility.CreateBasicAmount(giftCardsTotal),
                                                  Description = "Gift Cards"
                                              };
}
