    class Button
    {
        public Point Location { get; set; }
    }
    
    class Program
    {
        public static void Main()
        {
            var button = Util.GetButtonFromSomewhere();
            var location = button.Location;
            Util.DrawText("one", location);
            location.Y += 50;
            Util.DrawText("two", location);
            location.Y += 50;
            Util.DrawText("three", location);
        }
    }
