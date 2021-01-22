    public static string CapitalizeSentences(this string Input)
        {
            if (String.IsNullOrEmpty(Input))
                return Input;
            
            if (Input.Length == 1)
                return Input.ToUpper();
            
            Input = Regex.Replace(Input, @"\s+", " ");
            Input = Input.Trim().ToLower();
            Input = Char.ToUpper(Input[0]) + Input.Substring(1);
            var objDelimiters = new string[] { ". ", "! ", "? " };
            foreach (var objDelimiter in objDelimiters)
            {
                var varDelimiterLength = objDelimiter.Length;
                var varIndexStart = Input.IndexOf(objDelimiter, 0);
                while (varIndexStart > -1)
                {
                    Input = Input.Substring(0, varIndexStart + varDelimiterLength) + (Input[varIndexStart + varDelimiterLength]).ToString().ToUpper() + Input.Substring((varIndexStart + varDelimiterLength) + 1);
                    varIndexStart = Input.IndexOf(objDelimiter, varIndexStart + 1);
                }
            }
            return Input;
        }
