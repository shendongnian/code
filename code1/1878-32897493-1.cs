    using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
    using static System.Console;
    
    private enum Countries
        {
            NorthAmerica,
            Europe,
            Rusia,
            Brasil,
            China,
            Asia,
            Australia
        }
       [TestMethod]
            public void StringExtensions_On_TryParseAsEnum()
            {
                var countryName = "Rusia";
    
                Countries country;
                var isCountry = countryName.TryParseAsEnum(out country);
    
                WriteLine(country);
    
                IsTrue(isCountry);
                AreEqual(Countries.Rusia, country);
    
                countryName = "Don't exist";
    
                isCountry = countryName.TryParseAsEnum(out country);
    
                WriteLine(country);
    
                IsFalse(isCountry);
                AreEqual(Countries.NorthAmerica, country); // the 1rst one in the enumeration
            }
