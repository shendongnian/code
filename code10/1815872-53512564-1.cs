    List<string> colorList = new List<string> { "red", "red", "yellow", "blue", "blue", "orange", "green", "red" };
    
    var result = colorList.GroupBy(item => item).Select(item => new
                   {
                        Name = item.Key,
                        Count = item.Count()
                    })
                    .OrderByDescending(item => item.Count)
                    .ThenBy(item => item.Name).ToList();
