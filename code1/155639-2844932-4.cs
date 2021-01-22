    List<Order> zeroList = new List<Order>();
    while (startDate <= endDate)
    {
      zeroList.Add(new Order { OrderDateTime = startDate, OrderPrice = 0 });
      startDate = startDate.AddDays(1)
    }
    var comboList = zeroList.Union(dc.Orders.Where(b => b.OrderDateTime > Convert.ToDateTime(startDate.Date + startTS) && b.OrderDateTime <= Convert.ToDateTime(endDate.Date + endTS))
    var groupedTotalSales = comboList.GroupBy(b => b.OrderDateTime.Date)
      .Select(b => new { StartDate = Convert.ToDateTime(b.Key + startTS), EndDate = Convert.ToDateTime(b.Key + endTS), Sum = b.Sum(x => x.OrderPrice });
    foreach (totalSale in groupedTotalSales)
      Response.Write("From Date: " + totalSale.StartDate + " - To Date: " + totalSale.EndDate + ". Sales: " + String.Format("{0:0.00}", (decimal)totalSale.Sum) + "<br/>");
