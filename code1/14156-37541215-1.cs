      private static string ReverseString2(string text)
        {
            String rtext = "";
            for (int i = text.Length - 1; i >= 0; i--)
            {
                rtext = rtext + text[i];
            }
            return rtext;
        }
