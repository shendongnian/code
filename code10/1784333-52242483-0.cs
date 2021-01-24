    var result = List1.Concat(
                 List2.Select(list2Item => new List_Data
                 {
                     Material = list2Item.Material,
                     Batch = list2Item.Batch,
                     QTY = list2Item.QTY * -1
                 }))
                 .GroupBy(item => new { item.Material, item.Batch })
                 .Select(grouped => new List_Data
                 {
                     Material = grouped.First().Material,
                     Batch = grouped.First().Batch,
                     QTY = grouped.Sum(item => item.QTY)
                 })
                 .ToList();
