            /// <summary>
    /// This replaces the address block
    /// </summary>
    /// <param name="address">The address array </param>
    /// <param name="localDocText">the text we want to modify</param>
    /// <returns></returns>
    private string ReplaceAddressBlock(string[] address, string localDocText)
    {
        //This is done to force the array to have 6 indicies (with one potentially being empty
        string[] addressSize = new string[6];
        address.CopyTo(addressSize, 0);
        //defines the new save location of the object
        //add an xml linebreak to each piece of the address
        var addressString ="";
        var counter = 0;
        foreach (var t in address)
        {
            if (counter != 0)
            {
                addressString += " <w:p> <w:r><w:t> ";
            }
            addressString += t ;
            if (counter != 4)
            {
                addressString += "</w:t> </w:r></w:p> ";
            }
            counter += 1;
        }
        //look for the triple pipes then replace everything in them and them with the address
        var regExp = @"(\|\|\|).*(\|\|\|)";
        Regex regexText = new Regex(regExp, RegexOptions.Singleline);
        localDocText = regexText.Replace(localDocText, addressString);
        return localDocText;
    }
