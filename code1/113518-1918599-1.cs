     var query = context.Table
             .Where(t => t.Enabled 
                 && textClauses.Where(c => c.Contains).All(c => t.title.Contains(c.Text) )
                 && textClauses.Where(c => c.DoesNotContain).All(c => !t.title.Contains(c.Text) )
                 && dateClauses.Where(c => c.GreaterThan).All(c => t.date > c.Date) )
                 && dateClauses.Where(c => c.LesserThan).All(c => t.date < c.Date) )
              ).Select(t =>  new {
                   title = t.title
                   date = t.date
          });
