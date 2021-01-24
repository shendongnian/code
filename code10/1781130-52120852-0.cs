    public class Countries
    {
        protected IEnumerable<Country> _countries;
        public Countries(IEnumerable<Country> countries)
        {
            this._countries = countries;
        }
    }
