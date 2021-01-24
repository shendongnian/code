    var contractsId = waitingData.Select(data => data.ContractId).ToList();
    var pricingCriterias = table4.Where(criteria => contractsId.Contains(criteria.ContractId)
                                 .ToLookup(criteria => criteria.ContractId);
    var maxWaitingTime = 
        pricingCriterias.SelectMany(group => group)
                        .Where(criteria => criteria.PricingCriterionName = "WaitingTimeMax")
                        .Max(criteria => criteria.PricingCriterionValue);
    foreach (var waitingItem in waitingData)
    {
        // Calculate others waiting values
        var waitingPerPeriod = (WaitingTime - maxWaitingTime) / WaitingTimePeriod);
        var waitingPrice = waitingPerPeriod * WaitingTimeOverdue;
        var WaitingTimeCost = Math.Min(waitingPrice, OverDuePriceMax)
    }
    
                                 
