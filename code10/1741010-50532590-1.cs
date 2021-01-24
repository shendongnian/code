    var tokens = jsonToken.SelectToken("$.someArray").ToObject<List<Dictionary<string, string>>>().Where(p => !p.Keys.Contains("item2"));
            foreach (var token in tokens)
            {
               foreach(var item in token)
                {
                    Console.WriteLine(item.Key +":"+ item.Value);
                }
            }
            Console.ReadLine();
