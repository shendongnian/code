    public class Coffee
    {
        private bool _cream;
        private int _ounces;
        public Coffee Make { get new Coffee(); }
        public Coffee WithCream()
        {
            _cream = true;
            return this;
        }
        public Coffee WithOuncesToServe(int ounces)
        {
            _ounces = ounces;
            return this;
        }
    }
