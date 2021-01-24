    public static string ConvertNumerals(string input)
    {
        char[] inputCharArray = 
        input.ToCharArray().Where(ch=>char.IsDigit(ch)).ToArray();
        var newCharArr = new string[inputCharArray.Length];
        for (int i = 0; i<inputCharArray.Length; i++)
        {
            var c =  inputCharArray[i];  
            newCharArr[i] = char.GetNumericValue(c).ToString();
        }
        return string.Join("", newCharArr);
    }`
