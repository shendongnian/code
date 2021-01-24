    foreach (CustomerSite customerSite in listCustomerSite) {
        if (dictCustomer.TryGetValue(customerSite.Customer, out var siteSet)) {
            siteSet.Add(customerSite.Site);
        } else {
            siteSet = new SortedSet<string> { customerSite.Site };
            dictCustomer.Add(customerSite.Customer, siteSet);
        }
    }
