    public class Velocity : Tuple<double, double, string>
    {
        public Velocity(double Speed, double Direction, string Units) : base(Speed, Direction, Units) { }
        public double Speed { get { return this.Item1; } }
        public double Direction { get { return this.Item2; } }
        public string Units { get { return this.Item3; } }
    }
