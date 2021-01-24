            var enumerable = "1234567890"
                .Select(o => new Test(o));
            var results = new List<Test>();
            foreach (var item in enumerable)
            {
                if (!(item.Value > '3' && item.Value < '7'))
                {
                    item.Dispose();
                }
                else
                {
                    results.Add(item);
                }
            }
            // do something with results
            // ...
            // dispose
            foreach (var result in results)
                result.Dispose();
