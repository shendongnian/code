    static string Xor(string text, int key)
    {
        string result = "";
        for (int i = 0; i < text.Length; i++)
        {
            int charValue = Convert.ToInt32(text[i]); //get the ASCII value of the character
            charValue ^= key; //xor the value
            result += char.ConvertFromUtf32(charValue); //convert back to string
        }
        return result;
    }
