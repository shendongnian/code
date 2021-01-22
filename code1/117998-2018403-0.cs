    public sealed class DistanceUnit
    {
        public DistanceUnit(string name, string symbol, double scale)
        {
            Name = name;
            Symbol = symbol;
            Scale = scale;
        }
        public string Name { get; private set; }
        public string Symbol { get; private set; }
        public double Scale { get; private set; }
    }
    public abstract class Distance
    {
        protected Distance(double value)
        {
            this.Value = value;
        }
        protected Distance()
        {
        }
        public double Value { get; set; }
   
        public abstract DistanceUnit Unit { get; }
        public override string ToString()
        {
            return this.Value + " " + Unit.Symbol;
        }
        public static void Convert<TIn, TOut>(TIn original, out TOut result)
            where TIn : Distance, new()
            where TOut : Distance, new()
        {
            result = new TOut();
            var scale = result.Unit.Scale / original.Unit.Scale;
            result.Value = original.Value * scale;
        }
    }
    public sealed class Meter : Distance
    {
        private static readonly DistanceUnit s_Unit = new DistanceUnit("Meter", "m", 1);
        public Meter(double value) : base(value)
        {
        }
        public Meter()
        {
        }
        public override DistanceUnit Unit
        {
            get { return s_Unit; }
        }
    }
    public sealed class Kilometer : Distance
    {
        private static readonly DistanceUnit s_Unit = new DistanceUnit("Kilometer", "km", .001);
        public Kilometer()
        {
        }
        public Kilometer(double value)
            : base(value)
        {
        }
        public override DistanceUnit Unit
        {
            get { return s_Unit; }
        }
    }
