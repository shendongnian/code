    public class Driver : RailwayUser
    {
        public override void Notice(Colour state)
        {
            Console.WriteLine($"Driver see the {state.ToString()}");
        }
    }
