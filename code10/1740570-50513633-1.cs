    public class Nail : Part<Nail>
    {
        public override Maker<Nail> GetMaker()
        {
            return new Maker<Nail>() { Name = "Nail" };
        }
    }
    
    public class Screw : Part<Screw>
    {
        public override Maker<Screw> GetMaker()
        {
            return new Maker<Screw>() { Name = "Screw" };
        }
    }
