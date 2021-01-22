    public class Coffee
    {
        private bool _cream;
        private int _ounces;
        public static Coffee Make { get { return new Coffee(); } }
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
    var myMorningCoffee = Coffee.Make.WithCream().WithOuncesToServe(16);
