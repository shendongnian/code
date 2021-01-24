            var consSelect = cons.Select(grp => new
                         {
                             Parent = grp.Key,
                             ConsecutiveNodes = grp.Select((n, i) => new
                             {
                                 Index = i + 1,
                                 Node = n
                             }),
                             Count = grp.Count()
                         })
                         .ToList();
