    void Update(object obj, string navigation, object newval)
    {
        var firstSlash = navigation.IndexOf("/");
        if (firstSlash < 0)
        {
            obj.GetType().GetProperty(navigation).SetValue(obj, newval);
        }
        else
        {
            var header = navigation.Substring(0, firstSlash);
            var tail = navigation.Substring(firstSlash + 1);
            var subObj = obj.GetType().GetProperty(header).GetValue(obj);
            Update(subObj, tail, newval);
        }
    }
