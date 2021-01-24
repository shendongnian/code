    ...
    foreach (var r in records)
    {
        PurchaseOrderPreliminaryCSVModel tempResult = new PurchaseOrderPreliminaryCSVModel
        {
            Item1 = r.Item1,
            Item2 = r.Item2,
            Item3 = r.Item3,
            Item4 = r.Item4,
        };
        var designNames = _purchaseOrderRepository.GetPreliminaryDesignNames(fileName);
        tempResult.PreliminaryDesignNames.AddRange(designNames);
        result.Add(tempResult);
    }
    ...
