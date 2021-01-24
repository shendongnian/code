    public static IEnumerable<object> GetProps(object obj)
    {
        if (obj == null)
            yield break;
        var stack = new Stack<object>();
        stack.Push(obj);
        while (stack.Count > 0)
        {
            var current = stack.Pop();
            yield return current;
            var objType = current.GetType();
            var properties = objType.GetProperties();
            foreach (var property in properties)
            {
                object value = property.GetValue(obj, null);
                if (value == null)
                    continue;
                if (typeof(IEnumerable).IsAssignableFrom(property.PropertyType))
                {
                    var enumerable = (IEnumerable)value;
                    foreach (object child in enumerable)
                        stack.Push(child);
                }
                else
                {
                    stack.Push(value);
                }
            }
        }
    }
