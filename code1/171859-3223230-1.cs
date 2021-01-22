    public class StringTableProvider : ILanguagePrompts
    {
        public string this[string modelName, string propertyName]
        {
            get { return Get(modelName, propertyName) ?? "[" + propertyName+ "]"; }
        }
    
        public string Get(string modelName, string propertyName)
        {
            return Resource1.ResourceManager.GetString(modelName + "_" + propertyName);
        }
    }
