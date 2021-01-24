    var castMethod = this.GetType().GetMethod("CastList").MakeGenericMethod(type);
    value = castMethod.Invoke(null, new object[] { value, isArray });
    public static object CastList<T>(List<object> o, bool isArray) {
        var result = o.Cast<T>();
        return isArray ? (object)result.ToArray() : result.ToList();
    }
