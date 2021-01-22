    List<string>        list    = new List<string> { "a", "b", "c" };
    IEnumerable<string> strings = list;
    IEnumerable<object> objects = list;
    Type listType    = list.GetListType();           // string
    Type stringsType = strings.GetEnumeratedType();  // string
    Type objectsType = objects.GetEnumeratedType();  // BEWARE: object
