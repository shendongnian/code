    class Parent
    {
        Public IChild Child { get; set; }
    }
    ...
    Parent p = new Parent();
    IChild child = p.Child;
    Type childType = p.Child.GetType();
    ImportantEnum val = child.MyEnum
