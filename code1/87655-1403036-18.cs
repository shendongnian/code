    void SetString(string input, Action<string> setOutput)
    {
        if (!string.IsNullOrEmpty(input))
        {
            setOutput(input);
        }
    }
    void Main()
    {
        var person = new Person();
        SetString("test", value => person.Name = value);
        Debug.Assert(person.Name == "test");
    }
