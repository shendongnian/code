    var query = from row in dataTable
                group row by new { row.CustomerId, row.CustomerName } into g
                select new
                {
                    g.Key.CustomerId,
                    g.Key.CustomerName,
                    Cost = g.Sum(row => row.Cost)
                };
