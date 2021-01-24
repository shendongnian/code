    var results = list.GroupBy(x => x.MyDateTimeField.Date)
                      .Select(x =>
                                  {
                                     var count = x.Count();
                                     var good = x.Count(y => y.Content == "Good");
                                     var bad = x.Count(y => y.Content == "Bad");
                                     var result = new
                                                    {
                                                       Date = x.Key,
                                                       Good = good / (decimal)count,
                                                       Bad = bad / (decimal)count
                                                    };
                                     return result;
                                  });
    foreach (var item in results)
    {
         Console.WriteLine(string.Format("Date = {0}, Good = {1:P2}, Bad = {2:P2}", item.Date.Date, item.Good, item.Bad));
    }
