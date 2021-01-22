    // ....
    // (class Common)
    
    public static void With<T>(T property, Action<T> action) {
        action(property);
    }
    
    // ...
    // usage somewhere ...    
    Person person = GetPerson();
    Common.With(person, p => { p.Name = "test", p.Age = "123" });
