    public class AdditionalAttributeBlock : Dictionary<string, object>
    {
        public string BlockTitle => this["BlockTitle"] as string;
        public AdditionalAttribute Attribute => this[BlockTitle] as AdditionalAttribute;
        public AdditionalAttributeBlock(string title, AdditionalAttributeBlock attribute)
        {
            this["BlockTitle"] = title;
            this[title] = attribute;
        }
    }
