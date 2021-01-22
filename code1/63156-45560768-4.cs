    Student student = new Student
    {
        FirstName = "Alex",
        LastName = "Parker"
    };
    bool isOverridden = student.GetType()
        .GetMethod(
            name: nameof(ToString),
            bindingAttr: BindingFlags.Instance | BindingFlags.Public,
            binder: null,
            types: Type.EmptyTypes,
            modifiers: null
        ).IsOverridden(); // ExtMethod
    if (isOverridden)
    {
        Console.Out.WriteLine(student);
    }
