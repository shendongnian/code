    public enum TrafficColor { Red, Yellow, Green }
    public static void Main()
    {
        Console.WriteLine("Choose a traffic color: red, yellow, green?");
        var color = (TrafficColor)Enum.Parse(typeof(TrafficColor), Console.ReadLine());
        var result = string.Empty;
        // Creating the "switch"
        var mySwitch = new AdvancedSwitch<TrafficColor>();
        // Adding a single case
        mySwitch.AddHandler(TrafficColor.Green, delegate
        {
            result = "You may pass.";
        });
        // Adding multiple cases with the same action
        Action redAndYellowDelegate = delegate
        {
            result = "You may not pass.";
        };
        mySwitch.AddHandler(TrafficColor.Red, redAndYellowDelegate);
        mySwitch.AddHandler(TrafficColor.Yellow, redAndYellowDelegate);
        // Evaluating it
        mySwitch.ExecuteHandler(color, (TrafficColor[])Enum.GetValues(typeof(TrafficColor)));
        Console.WriteLine(result);
    }
