    var adjustmentChangeBySubBook =
        from provision in
            (from currentProvision in currentProvisions select new
                {
                    currentProvision.SubBook,
                    CurrentUSD = currentProvision.ProvisionUSD,
                    PreviousUSD = 0
                }).Concat
            (from prevProvision in prevProvisions select new
                {
                    prevProvision.SubBook,
                    CurrentUSD = 0,
                    PreviousUSD = prevProvision.ProvisionUSD
                })
        group provision by provision.SubBook into subBookGrouping select new
        {
            subBookGrouping.Key,
            Value = subBookGrouping.Sum(t => t.CurrentUSD - t.PreviousUSD)
        };
