    public abstract class Typedef<T, TDerived> where TDerived : Typedef<T, TDerived>, new()
    {
        private T _value;
        public static implicit operator T(Typedef<T, TDerived> t)
        {
            return t == null ? default : t._value;
        }
        
        public static implicit operator Typedef<T, TDerived>(T t)
        {
            return t == null ? default : new TDerived { _value = t };
        }
    }
    // Usage examples
    class CountryCode : Typedef<string, CountryCode> { }
    class CurrencyCode : Typedef<string, CurrencyCode> { }
    class Quantity : Typedef<int, Quantity> { }
    void Main()
    {
        var canadaCode = (CountryCode)"CA";
        var canadaCurrency = (CurrencyCode)"CAD";
        CountryCode cc = canadaCurrency;        // Compilation error
        Concole.WriteLine(canadaCode == "CA");  // true
        Concole.WriteLine(canadaCurrency);      // CAD
        var qty = (Quantity)123;
        Concole.WriteLine(qty);                 // 123
    }
