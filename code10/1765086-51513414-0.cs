            var result = JsonConvert.DeserializeObject<JArray>(your_json_string);
            var item = result.Children().First();
            var itemProperties = item.Children<JProperty>();
            foreach (var itemProperty in itemProperties.Where(x => x.Name.Contains("sub_cdr")))
            {
                Console.WriteLine(itemProperty.Name);
                MainCdr data = itemProperty.Value.ToObject<MainCdr>();
                Console.WriteLine(data.AcctId);
                Console.WriteLine(data.accountcode);
            }
