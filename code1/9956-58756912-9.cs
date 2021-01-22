    class CountryCode : Typedef<string, CountryCode> { }
    class CurrencyCode : Typedef<string, CurrencyCode> { }
    class Quantity : Typedef<int, Quantity> { }
    class Vector : Typedef<List<int>, Vector> { }
    void Main()
    {
        var canadaCode = (CountryCode)"CA";
        var canadaCurrency = (CurrencyCode)"CAD";
        CountryCode cc = canadaCurrency;        // Compilation error
        Concole.WriteLine(canadaCode == "CA");  // true
        Concole.WriteLine(canadaCurrency);      // CAD
        var qty = (Quantity)123;
        Concole.WriteLine(qty);                 // 123
        var vector = (Vector) new List<int> {1, 2, 3};
        ((List<int>)vector).Add(4);
    }
