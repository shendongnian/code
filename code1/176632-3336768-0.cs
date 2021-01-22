    public class Config
    {
       Dictionary<string, Provider> _providers = new Dictionary<string, Provider>();
       // .. all of your providers ..
       public int GetNumber(string provider)
       {
          if (!_providers.HasKey(provider))
             throw ArgumentException();
          return _providers[provider].Number;
       }
    }
