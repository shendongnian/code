    class Program
    {
        static void Main(string[] args)
        {
            List<Country> countryCollection = new List<Country>() {
                                            new Country("Afghanistan",34656032),
                                            new Country("Austria", 8857960),
                                            new Country("Brazil", 210147125),
                                            new Country("Denmark", 5789957),
                                            new Country("Russia", 144526636),
                                            new Country("China", 1403500365),
                                            new Country("Turkey", 80810525),
                                            new Country("Serbia", 7001444),
                                            new Country("Iraq", 37202572),
                                            new Country("San Marino", 33344) };
            var OrderedCountries = countryCollection.OrderByDescending(x => x.Population).ToList();
            foreach (var country in OrderedCountries)
            {
                Console.WriteLine($"The country {country.Name} has {country.Population} people");
            }
        }
    }
    public class Country
    {
        public string Name { get; set; }
        public int Population { get; set; }
        public Country(string name, int population)
        {
            Name = name;
            Population = population;
        }
    }
