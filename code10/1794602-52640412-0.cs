    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class YourAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (!(value is Dictionary<string, string>))
                return false;
            var dictionary = (Dictionary<string,string>)value;
            if (dictionary.Count > 10)
                return false;
            foreach (var keyValuePair in dictionary)
            {
                if (keyValuePair.Value.Length > 256)
                    return false;
            }
            return true;
        }
    }
