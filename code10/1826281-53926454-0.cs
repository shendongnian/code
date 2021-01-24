    public static class ViewModelExtension{
    	
    	public static CountryViewModel CreateViewModel(this List<Country> countries){
    		
    		var countryService = new CountryService();
    		
    		CountryViewModel flags = new CountryViewModel();
    		flags.Countries = countries;
    		flags.CountriesCount = countries.Count;
    		flags.EuropeanCountriesCount = countryService.GetContinentCount("Europe", countries);
    		flags.AsianCountriesCount = countryService.GetContinentCount("Asia", countries);
    		flags.AfricanCountriesCount = countryService.GetContinentCount("Africa", countries);
    		flags.SAmericanCountriesCount = countryService.GetContinentCount("South America", countries);
    		flags.NAmericanCountriesCount = countryService.GetContinentCount("North America", countries);
    		flags.AustralianCountriesCount = countryService.GetContinentCount("Australia", countries);
    		flags.CountriesArea = countryService.GetCountriesArea(countries).ToString("N0");
    		flags.CountriesPercent = countryService.CountCountriesPercent(flags.CountriesCount);
    		flags.CountriesAreaPercent = countryService.CountCountriesAreaPercent(countryService.GetCountriesArea(countries));
    		flags.ShareLink = "?id=" + sharingService.GenerateGuid();
    
    		return flags;
    	}
    }
