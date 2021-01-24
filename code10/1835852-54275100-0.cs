            var list = new List<Email>()
            {
                new Email() {SalesOrderNumber = 10, Depart = 1},
                new Email() {SalesOrderNumber = 10, Depart = 2},
                new Email() {SalesOrderNumber = 20, Depart = 2},
                new Email() {SalesOrderNumber = 20, Depart = 2},
            };
            var groups = list.GroupBy(e => e.SalesOrderNumber) // sort all emails by SalesOrderNumber
                .Select(g => g.GroupBy(e => e.Depart)) // sort groups by Depart
                .Aggregate((l, r) => l.Concat(r)); // aggregate result to only one collection of groups
            foreach (var group in groups)
            {
                Console.WriteLine($"Group of SalesOrderNumber: {group.First().SalesOrderNumber}, Depart: {group.Key}");
                foreach (var email in group)
                {
                    Console.WriteLine(email);
                }
            }
