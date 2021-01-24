    foreach (CustomerSite customerSite in listCustomerSite)
    {
        if (dictCustomer.TryGetValue(customerSite.Customer, out var siteList)) {
            siteList.Add(customerSite.Site);
        } else {
            siteList = new List<string> { customerSite.Site };
            dictCustomer.Add(customerSite.Customer, siteList);
        }
    }
