    // This naming strategy converts snake case names to upper camel case (a.k.a. proper case)
    public class ProperCaseFromSnakeCaseNamingStrategy : NamingStrategy
    {
        protected override string ResolvePropertyName(string name)
        {
            StringBuilder sb = new StringBuilder(name.Length);
            for (int i = 0; i < name.Length; i++)
            {
                char c = name[i];
                if (i == 0 || name[i - 1] == '_')
                    c = char.ToUpper(c);
                if (c != '_')
                    sb.Append(c);
            }
            return sb.ToString();
        }
    }
