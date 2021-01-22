    public static string Greet(string name, YourType whatever)
    {
        string greeting = "welcome  ";
        whatever.Greeting = string.Concat(greeting, name);
        return name;
    }
