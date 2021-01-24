    .Select(g => new Models.MODEL_LoadCardStatus {
        CardTypeID = g.First().CardTypeId,
        CardType = g.Key,
        transactionStatus = g.First().Status,
        UpdatedDate = g.Select(s => s.UpdateDate).Max()
    })
