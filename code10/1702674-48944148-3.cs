    .SelectMany(payer => payer.Statusses.DefaultIfEmpty(),
        (payer, status) => new
        {
            // payer properties:
            PayerId = payer.PayerId,
            PayerName = payer.Name,
            Reputation = payer.Reputation,
           
            // status properties:
            StatusDescription = status.Description,
            StatusValue = status.Value,
        });
 
