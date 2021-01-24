    public Dictionary<string, Expression<Func<T, object>>> CreateColumnMap<T>(List<string> columNameList) {
        var dictionary = new Dictionary<string, Expression<Func<T, object>>>();
        foreach (var columnName in columNameList) {            
            dictionary[columnName] = GetPropertyExpression<T>(columnName);
        }
        return dictionary;
    }
