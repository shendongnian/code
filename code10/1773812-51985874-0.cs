    QueryContainer query = new TermQuery()
            {
                Field = "OrderId",
                Value = "1"
            };
            var searchRequest = new SearchRequest(index: "testindex")
            {
                Query = query
            };
            var searchResult = client.Search<TestLogs>(searchRequest);
      foreach (var s in orderIdArray)
            {
                Console.WriteLine($"{i}:    OrderId:" + s.OrderID + " Event: " + s.Event + " Time: " + s.TimeStamp);
                i++;
            }
