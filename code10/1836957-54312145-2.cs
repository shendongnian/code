    var str = new[]
    {
       "FOD19-1","FOD33-2","FOD39","SÅL1","SÅL23-3","SÅL31-1","SÅL32-2","SÅL33-1","SÅL7-1"
    };
    var decimalSeparator = Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator;
    var orderDetailsDict = new BLOrderDetail().GetOrderDetails(orderId).ToDictionary(o => o.Sku, o => o) ;
    var orderDetailsSorting = orderDetailsDict.Keys.Select(s =>
              {
                  var key = s.Substring(0, 3);
                  var value = double.Parse(s.Replace(key, "").Replace("-", decimalSeparator));
                  return Tuple.Create(key, value, s);
              })
              .OrderBy(x => x.Item1)
              .ThenBy(x => x.Item2)
              .Select(x => x.Item3);
    List<OrderDetailItem> orderDetails = orderDetailsSorting.Select(key => rorderDetailsDict[key]).ToList();
