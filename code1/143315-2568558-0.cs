    var paypalItems = new List<PaymentDetailsItemType>(order.OrderItems.Count);
    // specifying that count is optional, but will increase performance because array space will have to be reallocated less often
    // ...
    paypalItems.Add(new PaymentDetailsItemType
                                                  {
                                                      Name = "Gift Cards",
                                                      Amount = ApiUtility.CreateBasicAmount(giftCardsTotal),
                                                      Description = "Gift Cards"
                                                  });
    
