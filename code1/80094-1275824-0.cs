    private string alphabet = "abcdefghijklmnopqrstuvwxyz"; 
       // or whatever you want.  Include more characters 
       // for more combinations and shorter URLs
    public string Encode(int databaseId)
    {
        string encodedValue = String.Empty;
        while (databaseId > encodingBase)
        {
            int remainder;
            encodedValue += alphabet[Math.DivRem(databaseId, alphabet.Length, 
                out remainder)-1].ToString();
            databaseId = remainder;
        }
        return encodedValue;
    }
    public int Decode(string code)
    {
        int returnValue;
        
        for (int thisPosition = 0; thisPosition < code.Length; thisPosition++)
        {
            char thisCharacter = code[thisPosition];
            returnValue += alphabet.IndexOf(thisCharacter) * 
                Math.Pow(alphabet.Length, code.Length - thisPosition - 1);
        }
        return returnValue;
    }
