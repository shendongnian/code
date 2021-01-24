    context.Entities
           .Where(e => values.Select(v => v.ColumnA).Contains(e.ColumnA) && values.Select(v => v.ColumnB).Contains(e.ColumnB))
           .AsEnumerable()
           .Where(e => values.Contains(new { e.ColumnA, e.ColumnB }))
           .Select(e => e.ID_column);
