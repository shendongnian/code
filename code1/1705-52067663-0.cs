    public enum Coolness
    {
        NotSoCool,
        Cool,
        VeryCool,
        SuperCool
    }
    
    public static class CoolnessExtensions
    {
        public static string ToString(this Coolness coolness)
        {
            switch (coolness)
            {
                case Coolness.NotSoCool:
                    return "Not so cool";
                case Coolness.Cool:
                    return "Cool";
                case Coolness.VeryCool:
                    return "Very cool";
                case Coolness.SuperCool:
                    return Properties.Settings.Default["SuperCoolDescription"].ToString();
                default:
                    throw new ArgumentException("Unknown amount of coolness", nameof(coolness));
            }
        }
    }
