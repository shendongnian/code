    using System;
    using System.Collections.Generic;
    
    enum Country
    {
        UnitedKingdom, 
        UnitedStates,
        France,
        Portugal
    }
    
    class Test
    {
        static readonly Dictionary<Country, string> CountryNames =
            new Dictionary<Country, string>
        {
            { Country.UnitedKingdom, "UK" },
            { Country.UnitedStates, "US" },
        };
        
        static string ConvertCountry(Country country) 
        {
            string name;
            return (CountryNames.TryGetValue(country, out name))
                ? name : country.ToString();
        }
        
        static void Main()
        {
            Console.WriteLine(ConvertCountry(Country.UnitedKingdom));
            Console.WriteLine(ConvertCountry(Country.UnitedStates));
            Console.WriteLine(ConvertCountry(Country.France));
        }
    }
