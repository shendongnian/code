    var groupedTotalSales = dc.Orders.Where(b => b.OrderDateTime > Convert.ToDateTime(startDate.Date + startTS) && b.OrderDateTime <= Convert.ToDateTime(endDate.Date + endTS))
      .GroupBy(b => b.OrderDateTime.Date)
      .Select(b => new { StartDate = b.Key, EndDate = Convert.ToDateTime(b.Key + endTS), Sum = b.Sum(x => x.OrderPrice });
    foreach (totalSale in groupedTotalSales)
      Response.Write("From Date: " + totalSale.StartDate + " - To Date: " + totalSale.EndDate + ". Sales: " + String.Format("{0:0.00}", (decimal)totalSale.Sum) + "<br/>")
