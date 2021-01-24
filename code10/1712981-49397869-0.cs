    public class Translations : List<SingleTranslation>
    {
        public SingleTranslation this[string identifier]
        {
            get
            {
                return this.FirstOrDefault(p => p.Identifier == identifier);
            }
            set
            {
                SingleTranslation translation = this.FirstOrDefault(p => p.Identifier == identifier);
                if (translation == null)
                {
                    this.Add(value);
                }
                else
                {
                    translation.Value = value.Value;
                }
            }
        }
    }
    
    public class SingleTranslation
    {
    	public SingleTranslation(string identifier, string value)
    	{
    		Identifier = identifier;
    		Value = value;
    	}
    	
        public string Identifier { get; set; }
        public string Value { get; set; }
    }
