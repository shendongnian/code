        List<string>        list             = new List<string> { "a", "b", "c" };
        IEnumerable<string> stringEnumerable = list;
        IEnumerable<object> objectEnumerable = stringEnumerable;
        Type listType             = list.GetListType();                    // string
        Type stringEnumerableType = stringEnumerable.GetEnumeratedType();  // string
        Type objectEnumerableType = objectEnumerable.GetEnumeratedType();  // BEWARE: object
