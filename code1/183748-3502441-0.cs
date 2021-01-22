    string original = "Explosive;a dynamic person";
    string[] split = original.Split(';');
    string[] capitalized = split.Select(s => CapitalizeFirstLetter(s)).ToArray();
    string joined = string.Join(";", capitalized);
    
    string CapitalizeFirstLetter(string str)
    {
        if (string.IsNullOrEmpty(str))
        {
            return str;
        }
    
        char[] chars = str.ToCharArray();
        char[0] = char.ToUpper(char[0]);
    
        return new string(chars);
    }
