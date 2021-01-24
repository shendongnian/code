    // your two tables: Payers and Statuses:
    IEnumerable<Payer> payers = ...
    IEnumerable<PayerStatus> statuses = ...
    // GroupJoin these two tables:
    var prayersWithTheirStatusses = payers.GroupJoin(statusses,
        payer => payer.Id,              // from each payer take the Id
        status => status.PayerId,       // from each status take the PayerId
        (payer, statusses) =>  new      // when they match, make a new object:
        {
            // take only the Payer properties you plan to use, for instance:
            PayerId = payer.Id,
            Name = payer.Name,
            Reputation = payer.Reputation,
            ...
            // from all payer's statuses, take only the properties you plan to use
            Statusses = statusses.Select(status => new
            {
                Description = status.Description,
                StatusValue = status.Value,
                ...
            })
            .ToList(),
        }
    }
