     bool IsProbablyGuid(string s)
        {
            int hexchars = 0;
            foreach(character c in string s)
            {
               if(IsValidHexChar(c)) 
                   hexchars++;          
            }
            return hexchars==32;
        }
