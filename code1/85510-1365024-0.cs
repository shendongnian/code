    public static object Nil
    {
        get
        {
            // **I took a guess at the syntax here - you should double check.**
            return new XAttribute(Xsi + "nil", true);
        }
    }
    // ......
    object nullableContent = ...;
    element.Add(
        new XElement(NS + "myNillableElement", nullableContent ?? Nil)
        );
