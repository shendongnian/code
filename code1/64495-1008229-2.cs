        enum Country
        {
        	UnitedKingdom = 0,
        	UnitedStates = 1,
        	France = 2,
        	Portugal = 3
        }
        
        enum CountryCode
        {
        	UK = 0,
        	US = 1,
        	FR = 2,
        	PT = 3
        }
        
        void Main()
        {
        	string countryCode = ((CountryCode)Country.UnitedKingdom).ToString();
        	Console.WriteLine(countryCode);
        	countryCode = ((CountryCode)Country.Portugal).ToString();
        	Console.WriteLine(countryCode);
        }
