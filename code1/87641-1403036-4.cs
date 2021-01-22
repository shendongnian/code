    void GetString(string input, Func<string> getOutput, Action<string> setOutput)
    {
        if (!string.IsNullOrEmpty(input))
        {
            setOutput(input);
        }
    }
    void Main()
    {
        var person = new Person();
        GetString("test", () => person.Name, value => person.Name = value);
        Debug.Assert(person.Name == "test");
    }
