    var distinctrecords = 
    (entity.Table.Join(entity.Table2, x => x.Column, y => y.Column, (x, y) => new {x, y})
                 .Select(@t => new {@t.x.Column2, @t.y.Column3}))
                 .GroupBy(t => t.Column2)
                 .Select(g => g.FirstOrDefault());
