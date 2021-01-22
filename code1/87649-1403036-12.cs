    void GetString(string input, object target, string propertyName)
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
        GetString("test", person, "Name");
        Debug.Assert(person.Name == "test");
    }
