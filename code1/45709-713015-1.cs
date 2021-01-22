            Dictionary<string, object> d1 = new Dictionary<string, object>();
            d1.Add("a", new object());
            d1.Add("b", new object());
            Dictionary<string, object> d2 = new Dictionary<string, object>();
            d2.Add("c", new object());
            d2.Add("d", new object());
            Dictionary<string, object> d3 = d1.Concat(d2).ToDictionary(e => e.Key, e => e.Value);
            foreach (var item in d3)
            {
                Console.WriteLine(item.Key);
            }
