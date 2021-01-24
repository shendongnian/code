    //TURN INTO QUERYABLE
    var finalList = unionList.AsQueryable();
    
    //DYNAMIC SORT
    if (input.SortModel?.SortModelItems?.Count > 0)
    {
        string sortQry = String.Empty;
        foreach (var i in input.SortModel.SortModelItems)
        {
            sortQry = sortQry + $"{StaticMethod.ConvertToNullableNested($"{i.ColumnName} {i.SortOrder}")}, ";
        }
        sortQry = sortQry.TrimEnd(", ");
        finalList = finalList.OrderBy(sortQry);
    }
    
    //RETURN AND REMEMBER TO .TAKE(Pagesize)
    return Tuple.Create(finalList.Take(input.PageSize).ToList(), finalRowCount);
----------
    public static string ConvertToNullableNested(string expression, string result = "", int index = 0)
        {
            //Transforms => "a.b.c" to "(a != null ? (a.b != null ? a.b.c : null) : null)"
            if (string.IsNullOrEmpty(expression))
                return null;
            if (string.IsNullOrEmpty(result))
                result = expression;
            var properties = expression.Split(".");
            if (properties.Length == 0 || properties.Length - 1 == index)
                return result;
            var property = string.Join(".", properties.Take(index + 1));
            if (string.IsNullOrEmpty(property))
                return result;
            result = result.Replace(expression, $"{property} == null ? null : {expression}");
            return ConvertToNullableNested(expression, result, index + 1);
        }
