            TableB.GroupBy(x => x.AId).Select(group => new { identifier = group.Key, MaxDate = group.Max(m => m.Date) }).ToList().ForEach(y =>
            {
                if (y.MaxDate <= DateTime.Now.Date)
                {
                    TableA.Where(g => g.Id == y.identifier).First().Status = true;
                }
            });
