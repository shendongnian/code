    class CountryCode : Typedef<string, CountryCode> { }
    class CurrencyCode : Typedef<string, CurrencyCode> { }
    class Quantity : Typedef<int, Quantity> { }
    var canadaCode = (CountryCode)"CA";
    var canadaCurrency = (CurrencyCode)"CAD";
    var qty = (Quantity)123;
    CountryCode cc = canadaCurrency;        // Compilation error
    Concole.WriteLine(canadaCode == "CA");  // true
    Concole.WriteLine(canadaCurrency);      // CAD
    Concole.WriteLine(qty);                 // 123
