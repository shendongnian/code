    var query = context.Table.Where(t => t.Enabled).Select(t =>  new {
                   title = t.title
                   date = t.date
          });
    query = query.Where(t => textClauses.Where(c => c.Contains).All(c => t.title.Contains(c.Text) );
    query = query.Where(t => textClauses.Where(c => c.DoesNotContain).All(c => !t.title.Contains(c.Text) );
    query = query.Where(t => dateClauses.Where(c => c.GreaterThan).All(c => t.date > c.Date) );
    query = query.Where(t => dateClauses.Where(c => c.LesserThan).All(c => t.date < c.Date) );
