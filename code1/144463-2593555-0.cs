            List<DateTime> dateTimes = new List<DateTime>();
            Dictionary<string, List<string>> data = new Dictionary<string, List<string>>();
            foreach (DateTime t in dateTimes)
            {
                if (!data.ContainsKey(t.ToShortDateString()))
                {
                    data.Add(t.ToShortDateString(), new List<string>());
                }
                data[t.ToShortDateString()].Add(t.ToShortTimeString());
            }
            foreach (string key in data.Keys)
                data[key].Sort();
            foreach (var pair in data)
            {
                Console.WriteLine(pair.Key);
                foreach (string time in pair.Value)
                    Console.WriteLine(time);
                Console.WriteLine();
            }
