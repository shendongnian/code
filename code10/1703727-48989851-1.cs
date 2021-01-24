	public class CamelCaseDictionaryKeyNamingStrategy : DefaultNamingStrategy
    {
        public CamelCaseDictionaryKeyNamingStrategy() : base() { this.ProcessDictionaryKeys = true; }
        public override string GetDictionaryKey(string key)
        {
            if (ProcessDictionaryKeys && !string.IsNullOrEmpty(key))
            {
                if (char.ToUpperInvariant(key[0]) != key[0])
                {
                    var builder = new StringBuilder(key) { [0] = char.ToUpperInvariant(key[0]) };
                    return builder.ToString();
                }
            }
            return key;
        }
    }
	
