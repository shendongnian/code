     var result = data.GroupBy(x => new { 
                       x.Name,                                  // Group on Name
                       x.Date,                                  // And date
                       IsHourNumeric=x.Hour.All(Char.IsNumber)  // And whether Hour is numeric
                 })
                .Select(g => new {
                  Name = g.Key.Name,
                  Date = g.Key.Date,
                  Hour = g.Key.IsHourNumeric 
                           ? g.Select(x => int.Parse(x.Hour)).Sum().ToString() // If hour was numeric sum
                           : g.First().Hour, // Otherwise just take the first item ?!?
                  SubTasks = g.Select(x => x.SubTask)
                });
