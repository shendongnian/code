    public static string Replace(string text, string[] toReplace, string replaceWith)
        {
            foreach (string str in toReplace)
               text = text.Replace(str, replaceWith);
            return text;
        }
