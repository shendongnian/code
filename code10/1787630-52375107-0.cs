    public class CamelCaseNamingStrategy : NamingStrategy
    {
        // ...
        protected override string ResolvePropertyName(string name)
        {
            return StringUtils.ToCamelCase(name);
        }
    }
