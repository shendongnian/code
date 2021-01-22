    public class Meter
    {
        private int _powerRating = 0;
        private Production _production;
        public Meter()
        {
            _production = new Production();
            _production.OnRequestPowerRating += new Func<int>(delegate { return _powerRating; });
            _production.DoSomething();
        }
    }
    public class Production
    {
        protected int RequestPowerRating()
        {
            if (OnRequestPowerRating == null)
                throw new Exception("OnRequestPowerRating handler is not assigned");
            return OnRequestPowerRating();
        }
        public void DoSomething()
        {
            int powerRating = RequestPowerRating();
            Debug.WriteLine("The parents powerrating is :" + powerRating);
        }
        public Func<int> OnRequestPowerRating;
    }
