    var rowsInOrder = new List<string>();
            foreach (var grouping in dates
                .OrderBy(s => DateTime.ParseExact(s, "yyyyMM", CultureInfo.CurrentCulture).Month).GroupBy(s =>
                    DateTime.ParseExact(s, "yyyyMM", CultureInfo.CurrentCulture).Month))
            {
                rowsInOrder.AddRange(grouping.OrderBy(s => s));
            }
