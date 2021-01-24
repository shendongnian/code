     var result = list.GroupBy(i => i.GroupingKey).ToList().Select(group => 
                    new Item
                    {
                        Values = group.SelectMany(item => item.Values.Select((value, index) => new { value, index }))
                          .GroupBy(item => item.index)
                          .Select(a => a.Sum(e => e.value))
                          .ToList(),
                        GroupingKey = group.Select(i=>i.GroupingKey).FirstOrDefault(),
                        Cycle = group.Select(i=>i.Cycle).FirstOrDefault()
                    }
                );
