`
static void Main(string[] args)
        {
            Country[] countryCollection = {
                new Country("Afghanistan", 34656032),
                new Country("Austria", 8857960),
                new Country("Brazil", 210147125),
                new Country("Denmark", 5789957),
                new Country("Russia", 144526636),
                new Country("China", 1403500365),
                new Country("Turkey", 80810525),
                new Country("Serbia", 7001444),
                new Country("Iraq", 37202572),
                new Country("San Marino", 33344)
            };
            Array.Sort(countryCollection, delegate(Country country1, Country country2) {
                return country1.Population.CompareTo(country2.Population);
            });
            foreach (Country country in countryCollection) Console.WriteLine("Country name: " + country.Name + " Population: " + country.Population);
            Console.ReadKey();        
        }
`
See http://www.csharp-examples.net/sort-array/ for more details.
