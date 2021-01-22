    var aggregates = new {
    Count = context.TableName.Count(),
    Sum = context.TableName.Sum(t => t.Amount),
    Avg = context.TableName.Avg(t => t.Amount),
    Min = context.TableName.Min(t => t.Amount),
    Max = context.TableName.Max(t => t.Amount)
    };
               
