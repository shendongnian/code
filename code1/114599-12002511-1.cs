    public interface IMeter
    {
        int PowerRating { get; }
    }
    public class Meter : IMeter
    {
        private int _powerRating = 0;
        private Production _production;
        public Meter()
        {
            _production = new Production(this);
            _production.DoSomething();
        }
        public int PowerRating { get { return _powerRating; } }
    }
    public class Production
    {
        private IMeter _meter;
        public Production(IMeter meter)
        {
            _meter = meter;
        }
        public void DoSomething()
        {
            Debug.WriteLine("The parents powerrating is :" + _meter.PowerRating);
        }
    }
