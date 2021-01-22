    static class Extensions
    {
            public static string RemoveLastChars(this String text, string suffix)
            {            
                char[] trailingChars = suffix.ToCharArray();
    
                if (suffix == null) return text;
                return text.TrimEnd(trailingChars);
            }
    
    }
