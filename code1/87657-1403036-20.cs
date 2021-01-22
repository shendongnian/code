    void SetString(string input, object target, string propertyName)
    {
        if (!string.IsNullOrEmpty(input))
        {
            prop = target.GetType().GetProperty(propertyName);
            prop.SetValue(target, input);
        }
    }
    void Main()
    {
        var person = new Person();
        SetString("test", person, nameof(Person.Name));
        Debug.Assert(person.Name == "test");
    }
