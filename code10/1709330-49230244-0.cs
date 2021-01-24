     var dictionary = new Dictionary<DateTime, int>()
            {
                { new DateTime(2018, 10, 03, 3, 40, 00), 2 },
                { new DateTime(2018, 10, 04, 4, 40, 00), 5 },
                { new DateTime(2018, 11, 02, 5, 40, 00), 2 },
                { new DateTime(2018, 11, 03, 6, 40, 00), 3 },
                { new DateTime(2018, 11, 04, 6, 40, 00), 4 },
            };
            var temp = dictionary.GroupBy(
                        p => p.Key.Month,
                        p => p.Value,
                        (date, val) => new { Date = date, Value = val.ToList().Last() });
