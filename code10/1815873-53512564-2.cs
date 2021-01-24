    var result = colorList.GroupBy(item => item).Select(item => new
                   {
                        Name = item.Key,
                        Count = item.Count()
                    })
                    .OrderByDescending(item => item.Count)
                    .ThenBy(item => item.Name).ToList();
