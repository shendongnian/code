        List<string>        list             = new List<string> { "a", "b", "c" };
        IEnumerable<string> stringEnumerable = list;
        IEnumerable<object> objectEnumerable = stringEnumerable;
        Type listType             = list.GetListType();                     // string
        Type stringEnumerableType = stringEnumerable.GetEnumertatedType();  // string
        Type objectEnumerableType = objectEnumerable.GetEnumertatedType();  // BEWARE: object
