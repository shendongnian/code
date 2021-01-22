public static string TrimLastEntry(string text)
{
     // input is valid ?, check any additional rules of your own....
     if (string.IsNullOrEmpty(text))
     {
          return text;
     }
            
     // get last index of a non digit char
     int idx = text.Length - 1;
     for (; idx > 0; --idx)
     {
         if (!char.IsDigit(text[idx]))
         {
             break;
         }
     }
     // replace the last 
     return text.Remove(idx + 1);
}
