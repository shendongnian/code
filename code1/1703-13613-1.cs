        /// <summary>
        /// Add spaces to separate the capitalized words in the string, 
        /// i.e. insert a space before each uppercase letter that is 
        /// either preceded by a lowercase letter or followed by a 
        /// lowercase letter (but not for the first char in string). 
        /// This keeps groups of uppercase letters - e.g. acronyms - together.
        /// </summary>
        /// <param name="pascalCaseString">A string in PascalCase</param>
        /// <returns></returns>
        public static string Wordify(string pascalCaseString)
        {            
            Regex r = new Regex("(?<=[a-z])(?<x>[A-Z])|(?<=.)(?<x>[A-Z])(?=[a-z])");
            return r.Replace(pascalCaseString, " ${x}");
        }
