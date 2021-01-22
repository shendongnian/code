  public static string ChrTran(string cSearchIn, string cSearchFor, string cReplaceWith)
        {
            string result = "";
            dynamic inArray = cSearchIn.ToCharArray();
            foreach (var caracter in inArray)
            {
                int position = cSearchFor.IndexOf(caracter);
                result = result + cReplaceWith.Substring(position, 1);
            }
            
            return result;
        }</pre>
