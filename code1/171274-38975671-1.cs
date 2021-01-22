    public static class StringExtensions 
    {
        public static string ToAlphaNumeric(this string self, params char[] allowedCharacters)
        {
            return new string(Array.FindAll(self.ToCharArray(), c => char.IsLetterOrDigit(c) || allowedCharacters.Contains(c)));
        }
    }
