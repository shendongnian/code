        .AsEnumerable()
        .Select(fetchedCustomerInfo => new
        {
             Id = fetchedCustomerInfo.Id,
             ...
             TimeSpent = TimeSpent.FromTicks(fetchedCustomerInfo.TimeSpentTicks),
             NumberOfAppearanceDays = fetchedCustomerInfo.NumberOfAppearanceDays,
        });
