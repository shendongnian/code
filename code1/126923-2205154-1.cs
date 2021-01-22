    public static string Greet(string name, Label label)
    {
        const string greeting = "welcome  ";
        string concat = string.Concat(greeting, name);
        label.Text = concat;
        return name;
    }
