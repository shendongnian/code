    List<string>        list             = new List<string> { "a", "b", "c" };
    IEnumerable<string> stringEnumerable = list;
    IEnumerable<object> objectEnumerable = stringEnumerable;
    Type listType         = list.GetListType();                    // string
    Type stringEnumblType = stringEnumerable.GetEnumeratedType();  // string
    Type objectEnumblType = objectEnumerable.GetEnumeratedType();  // BEWARE: object
