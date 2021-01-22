    using System;
    
    [AttributeUsage(AttributeTargets.All)]
    public class X: Attribute
    {}
    [AttributeUsage(AttributeTargets.All)]
    public class XAttribute: Attribute
    {}
    [X]                  // Error: ambiguity
    class Class1 {}
    [XAttribute]         // Refers to XAttribute
    class Class2 {}
    [@X]                  // Refers to X
    class Class3 {}
    [@XAttribute]         // Refers to XAttribute
    class Class4 {}
