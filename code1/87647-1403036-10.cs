    void GetString(string input, Action<string> setOutput)
    {
        if (!string.IsNullOrEmpty(input))
        {
            setOutput(input);
        }
    }
    void Main()
    {
        var person = new Person();
        GetString("test", value => person.Name = value);
        Debug.Assert(person.Name == "test");
    }
