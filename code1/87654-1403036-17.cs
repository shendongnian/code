    string GetString(string input, string output)
    {
        if (!string.IsNullOrEmpty(input))
        {
            return input;
        }
        return output;
    }
    void Main()
    {
        var person = new Person();
        person.Name = GetString("test", person.Name);
        Debug.Assert(person.Name == "test");
    }
