    var contractsId = 
        waitingData.AsEnumerable()
                   .Select(row => row.Field<int>("ContractId"))
                   .ToList();
    var pricingCriterias = 
        table4.AsEnumerable()
              .Where(row => contractsId.Contains(row => row.Field<int>("ContractId"))
              .ToLookup(row => row.Field<int>("ContractId"));
    var maxWaitingTime = 
        pricingCriterias.SelectMany(group => group)
                        .Where(row => row.Field<string>("PricingCriterionName") = "WaitingTimeMax")
                        .Max(row => row.Field<int>("PricingCriterionValue"));
    foreach (var waitingItem in waitingData)
    {
        // Calculate others waiting values
        var waitingPerPeriod = (WaitingTime - maxWaitingTime) / WaitingTimePeriod);
        var waitingPrice = waitingPerPeriod * WaitingTimeOverdue;
        var WaitingTimeCost = Math.Min(waitingPrice, OverDuePriceMax)
    }
    
                                 
