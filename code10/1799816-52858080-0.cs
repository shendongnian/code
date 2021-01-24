    public class CustomNamingStrategy : CamelCaseNamingStrategy
    {
        protected override string ResolvePropertyName(string propertyName)
        {
            if (propertyName.Equals("ID"))
                return "id";
            // return the camelCase
            propertyName = base.ResolvePropertyName(propertyName);
            if (propertyName.EndsWith("ID"))
                propertyName = propertyName.Substring(0, propertyName.Length - 1) + "d";
            return propertyName;
        }
    }
