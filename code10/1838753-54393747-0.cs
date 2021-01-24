            //Problem #2 method///////////////////////////////////////////////////////
            public static string EncryptingMethod(string normalString)
            {
                string vowels = "[aeiouyAEIOUY]"; //sets the letters you need to replace
                string replacement = "-";//what to replace the vowels with
    
                Regex rep = new Regex(vowels); //initiate the Regex
    
                string updatedString = rep.Replace(normalString, replacement); //rep will now look up for each character in VOWELS and update it with REPLACEMENT
    
                return updatedString;
            }
