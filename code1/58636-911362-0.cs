            var index = new Dictionary<string, List<string>>();
            foreach (var str in stringArray) {
                string[] split = str.Split(',');
                List<string> items;
                if (!index.TryGetValue(split[0], out items)) {
                    items = new List<string>();
                    index[split[0]] = items;
                }
                items.Add(split[1]); 
            }
            var transformed = new List<List<string>>();
            foreach (List<string> list in index.Values) {
                transformed.Add(list); 
            }
