        static void Main(string[] args)
        {
            string illegalCharacters = "!@#$%^&*()\\/{}|<>,.~`?"; //We'll call these the bad guys
            string goodUserName = "John Wesson";                   //This is a good guy. We know it. We can see it!
                                                                   //But what if we want the program to make sure?
            string badUserName = "*_Wesson*_John!?";                //We can see this has one of the bad guys. Underscores not restricted.
            Console.WriteLine("goodUserName " + goodUserName +
                (!HasWantedCharacters(goodUserName, illegalCharacters) ?
                " contains no illegal characters and is valid" :      //This line is the expected result
                " contains one or more illegal characters and is invalid"));
            string captured = "";
            Console.WriteLine("badUserName " + badUserName +
                (!HasWantedCharacters(badUserName, illegalCharacters, out captured) ?
                " contains no illegal characters and is valid" :
                //We can expect this line to print and show us the bad ones
                " is invalid and contains the following illegal characters: " + captured));  
            
        }
        //Takes a string to check for the presence of one or more of the wanted characters within a string
        //As soon as one of the wanted characters is encountered, return true
        //This is useful if a character is required, but NOT if a specific frequency is needed
        //ie. you wouldn't use this to validate an email address
        //but could use it to make sure a username is only alphanumeric
        static bool HasWantedCharacters(string source, string wantedCharacters)
        {
            foreach(char s in source) //One by one, loop through the characters in source
            {
                foreach(char c in wantedCharacters) //One by one, loop through the wanted characters
                {
                    if (c == s)  //Is the current illegalChar here in the string?
                        return true;
                }
            }
            return false;
        }
        //Overloaded version of HasWantedCharacters
        //Checks to see if any one of the wantedCharacters is contained within the source string
        //string source ~ String to test
        //string wantedCharacters ~ string of characters to check for
        static bool HasWantedCharacters(string source, string wantedCharacters, out string capturedCharacters)
        {
            capturedCharacters = ""; //Haven't found any wanted characters yet
            foreach(char s in source)
            {
                foreach(char c in wantedCharacters) //Is the current illegalChar here in the string?
                {
                    if(c == s)
                    {
                        if(!capturedCharacters.Contains(c.ToString()))
                            capturedCharacters += c.ToString();  //Send these characters to whoever's asking
                    }
                }
            }
            if (capturedCharacters.Length > 0)  
                return true;
            else
                return false;
        }
    
