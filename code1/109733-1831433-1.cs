    public enum Areas
    {
        [Description("Area 1")]
        Area1 = 10,
        [Description("Area 2")]
        Area2 = 20,
        [Description("Area 3")]
        Area3 = 30
    }
    Areas x = Areas.Area1;
    string xName = x.ToString();
