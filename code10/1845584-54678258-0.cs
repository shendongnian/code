            JObject parsedJson = JObject.Parse(responseBody);
            if (parsedJson != null)
            {
                JToken tickers = parsedJson["tickers"];
                List<string> tickerKeys = tickers.Value<JObject>()
                    .Properties()
                    .Select(p => p.Name)
                    .ToList();
                foreach(string key in tickerKeys)
                {
                    Console.WriteLine(tickers[key]["symbol"]);
                }
            }
