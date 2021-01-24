    public static object LookUp(List<dynamic> lst, string propName, object value)
    {
        return lst.FindAll(i =>
        {
            var dic = i as IDictionary<string, object>;
            return dic.Keys.Any(key => dic[key].ToString().Contains(value.ToString()));
        });
    }
