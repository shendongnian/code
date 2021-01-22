    public class Country
    {
        public string Name { get; set; }
        public IList<City> Cities { get; set; }
        public Country(string _name)
        {
            Cities = new List<City>();
            Name = _name;
        }
    }
