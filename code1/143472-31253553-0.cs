        public static int Search(this string yourString, string yourMarker, int yourInst = 1, bool caseSensitive = true)
        {
            //returns the placement of a string in another string
            int num = 0;
            int currentInst = 0;
            //if optional argument, case sensitive is false convert string and marker to lowercase
            if (!caseSensitive) { yourString = yourString.ToLower(); yourMarker = yourMarker.ToLower(); }
            int myReturnValue = 0;
            try
            {
                while (num < yourString.Length)
                {
                    string testString = yourString.Substring(num, yourMarker.Length);
                   
                    if (testString == yourMarker)
                    {
                        currentInst++;
                        if (currentInst == yourInst)
                        {
                            myReturnValue = num;             
                            break;
                        }                        
                    }
                    num++;
                }
            }
            catch
            {
                myReturnValue = 0;
            }
            return myReturnValue;
        }
        public static int Search(this string yourString, char yourMarker, int yourInst = 1, bool caseSensitive = true)
        {
            //returns the placement of a string in another string
            int num = 0;
            int currentInst = 0;
            var charArray = yourString.ToArray<char>();
            int myReturnValue = 0;
            if (!caseSensitive)
            {
                yourString = yourString.ToLower();
                yourMarker = Char.ToLower(yourMarker);
            }
            while (num <= charArray.Length)
            {                
                if (charArray[num] == yourMarker)
                {
                    currentInst++;
                    if (currentInst == yourInst)
                    {
                        myReturnValue = num;
                        break;
                    }
                }
                num++;
            }
            return myReturnValue;
        }
