    static string jonsString = (@"{
			'property1': 1,
			'property2': 2,
			'someArray': [
				{
					'item1': 1,
					'item2': 2
				},
				{
					'item1': 5,
                    'item2': 2
				}
			]
		}");
     var tokens = JObject.Parse(jonsString)["someArray"].ToObject<List<Dictionary<string, string>>>().Where(p=>!p.Keys.Contains("item2"));
            foreach (var token in tokens)
            {
               foreach(var item in token)
                {
                    Console.WriteLine(item.Key +":"+ item.Value);
                }
            }
            Console.ReadLine();
