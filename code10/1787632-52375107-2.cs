    class CustomCamelCaseNamingStrategy : CamelCaseNamingStrategy
    {
        protected override String ResolvePropertyName(String propertyName)
        {
            return this.toCamelCase(propertyName);
        }
        private string toCamelCase(string s)
        {
	        if (!string.IsNullOrEmpty(s) && char.IsUpper(s[0]))
	        {
		        char[] array = s.ToCharArray();
		        for (int i = 0; i < array.Length && (i != 1 || char.IsUpper(array[i])); i++)
		        {
			        bool flag = i + 1 < array.Length;
			        if ((i > 0 & flag) && !char.IsUpper(array[i + 1]) && !char.IsNumber(array[i + 1]))
			        {
				        break;
			        }
			        char c = char.ToLower(array[i], CultureInfo.InvariantCulture);
			        array[i] = c;
		        }
		        return new string(array);
	        }
	        return s;
        }
    }
