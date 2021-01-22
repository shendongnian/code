    // in your using-section, add this:
    using Roundsman.BAL;
    // keep this in your normal location
    var nCounts = from sale in sal
                  select new
                  {
                      SaleID = sale.OrderID,
                      LineItem = GetLineItem(sale.LineItems)
                  };
    foreach (var item in nCounts)
    {
        foreach (var itmss in item.LineItem)
        {
            itemsal.Add(CreateWeeklyStockList(itmss));
        }
    }
    // add this as method somewhere
    WeeklyStockList CreateWeeklyStockList(LineItem lineItem)
    {
        string name = itmss.Item.Name.ToString();  // isn't Name already a string?
        string code = itmss.Item.Code.ToString();  // isn't Code already a string?
        string description = itmss.Item.Description.ToString();  // isn't Description already a string?
        int quantity = Convert.ToInt32(itmss.Item.Quantity); // wouldn't (int) or "as int" be enough?
        return new WeeklyStockList(
                     name, 
                     code, 
                     description,
                     quantity, 
                     2, 2, 2, 2, 2, 2, 2, 2, 2
                  );
    }
    // also add this as a method
    LineItem GetLineItem(IEnumerable<LineItem> lineItems)
    {
        // add a null-check
        if(lineItems == null)
            throw new ArgumentNullException("lineItems", "Argument cannot be null!");
        // your original code
        from sli in lineItems
        group sli by sli.Item into ItemGroup
        select new
        {
            Item = ItemGroup.Key,
            Weeks = ItemGroup.Select(s => s.Week)
        }
    }
