    foreach (DateClause clause in dateClauses)
    {
        var capturedClause = clause;
        switch (clause.Operator)
        {
                case Operator.GreaterThan:
                        query = query.Where(l => l.date > capturedClause.Date);
                        break;
                case Operator.LessThan
                        query = query.Where(l => l.date < capturedClause.Date);
                        break;
        }               
    }
