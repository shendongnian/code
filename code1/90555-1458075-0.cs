        string[] columnNames = { "Name", "DoB" };
        string query = "2008";
        var row = Expression.Parameter(typeof(Data), "row");
        Expression body = null;
        Expression testVal = Expression.Constant(query, typeof(string));
        foreach (string columnName in columnNames)
        {
            var col = Expression.PropertyOrField(row, columnName);
            Expression colTest = Expression.Call(
                Expression.Call(col, "ToString", null, null),
                "Contains", null, testVal);
            body = body == null ? colTest : Expression.OrElse(body, colTest);
        }
        Expression<Func<Data,bool>> predicate
            = body == null ? x => false : Expression.Lambda<Func<Data,bool>>(
                  body, row);
