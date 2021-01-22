    var columnLookup =
        (from row in _cells
         from col in row.Value
         let cell = new { Row = row.Key, Column = col.Key, Value = col.Value }
         group cell by cell.Column into g
         select new
         {
             Column = g.Key,
             Rows = g.ToDictionary(c => c.Row, c => c.Value)
         }).ToDictionary(c => c.Column, c => c.Rows);
