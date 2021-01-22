    public static IEnumerable<MyObject> ContainsOneOfTheseKeywords(
            this IQueryable<MyObject> qry, List<string> keywords, char sep)
    {
        List<List<MyObject>> parts = new List<List<MyObject>>();
        foreach (string keyw in keywords)
            parts.Add((
                from obj in qry
                where obj.MyProperty == keyw ||
                      obj.MyProperty.IndexOf(sep + keyw + sep) != -1 ||
                      obj.MyProperty.IndexOf(keyw + sep) >= 0 ||
                      obj.MyProperty.IndexOf(sep + keyw) ==
                          obj.MyProperty.Length - keyw.Length - 1
                select obj).ToList());
        IEnumerable<MyObject> union = null;
        bool first = true;
        foreach (List<MyObject> part in parts)
        {
            if (first)
            {
                union = part;
                first = false;
            }
            else
                union = union.Union(part);
        }
        return union.ToList();
    }
