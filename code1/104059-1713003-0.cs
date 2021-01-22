            List<object> x = new List<object>();
            x.Add("A");
            x.Add("B");
            x.Add("C");
            x.Add("D");
            x.Add("B");
            var z = x.Where(p => p == "A");
            z = x.Where(p => p == "B");
