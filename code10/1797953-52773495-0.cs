    public static List<T> UpdateProp_Ideal<T, TProperty>(this List<T> foos, Expression<Func<T, TProperty>> propertyFunc, TProperty valueToSet)
    {
        var body = Expression.MakeBinary(ExpressionType.Assign, propertyFunc.Body, Expression.Constant(valueToSet));            
        var newFunc = Expression.Lambda<Action<T>>(body, propertyFunc.Parameters).Compile();            
        foos.ForEach(newFunc);            
        return foos;
    }
