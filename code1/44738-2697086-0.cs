    public static class ListExtenstions
    {
        public static List<Person> OrderList(this List<Person> list, string attributeName, PersonAttribute defaultAttribute)
        {
            return OrderList(list, attributeName, defaultAttribute, x => x);
        }
        public static List<Person> OrderList<T>(this List<Person> list, string attributeName, PersonAttribute defaultAttribute, Func<string, T> convertion)
        {
            return list.OrderBy(x => convertion((x.Attributes.FirstOrDefault(y => y.Name == attributeName) ?? defaultAttribute).Value)).ToList();
            // Query Syntax
            //return
            //    (from p in list
            //     let attribute = p.Attributes.FirstOrDefault(a => a.Name == attributeName) ?? defaultAttribute
            //     orderby attribute.Value
            //     select p).ToList();
        }
    }
