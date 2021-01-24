    public class Planet : SWAPIEntity
    {
        public static string rootUrl { get; } = "planets";
        // Or newer simpler syntax:
        // public static string rootUrl => "planets";
        public string climate { get; set; }
    }
