            static readonly Regex rePattern = new Regex(@"\{([^\}]+)\}", RegexOptions.Compiled);
        /// <summary>
        /// Shortcut for string.Format. Format string uses named parameters like {name}.
        /// 
        /// Example: 
        /// string s = Format("{age} years old, last name is {name} ", new {age = 18, name = "Foo"});
        ///
        /// </summary>
        /// <param name="format"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public static string FN<T>(this string pattern, T template)
        {
            Dictionary<string, string> cache = new Dictionary<string, string>();
            return rePattern.Replace(pattern, match =>
            {
                string key = match.Groups[1].Value;
                string value;
                if (!cache.TryGetValue(key, out value))
                {
                    var prop = typeof(T).GetProperty(key);
                    if (prop == null)
                    {
                        throw new ArgumentException("Not found: " + key, "pattern");
                    }
                    value = Convert.ToString(prop.GetValue(template, null));
                    cache.Add(key, value);
                }
                return value;
            });
        }
